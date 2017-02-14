#define USE_GS_AUTH_API

using Steamworks;
using UnityEngine;

namespace Brawler.Networking
{
    public class CustomNetworkManager : MonoBehaviour
    {
        public static CustomNetworkManager Instance { get { return _instance ?? new GameObject("NetworkManager").AddComponent<CustomNetworkManager>(); } }
        public bool ConnectedToSteam { get { return _connectedToSteam; } }


        private static CustomNetworkManager _instance;
        private Callback<SteamServersConnected_t> _callbackSteamServersConnected;
        private Callback<SteamServerConnectFailure_t> _callbackSteamServersConnectFailure;
        private Callback<SteamServersDisconnected_t> _callbackSteamServersDisconnected;
        private Callback<GSPolicyResponse_t> _callbackPolicyResponse;
        private Callback<ValidateAuthTicketResponse_t> _callbackGsAuthTicketResponse;
        private Callback<P2PSessionRequest_t> _callbackP2PSessionRequest;
        private Callback<P2PSessionConnectFail_t> _callbackP2PSessionConnectFail;
        private const string BrawlerServerVersion = "1.0.0.0";
        private const ushort BrawlerAuthenticationPort = 8766;
        private const ushort BrawlerServerPort = 27015;
        private const ushort BrawlerMasterServerUpdaterPort = 27016;
        private bool _initialized;
        private bool _connectedToSteam;
        private string _serverName = "Test Server";
        private string _mapName = "Test Map";
        private int _maxPlayers = 2;
        
        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _callbackSteamServersConnected = Callback<SteamServersConnected_t>.CreateGameServer(OnSteamServersConnected);
            _callbackSteamServersConnectFailure = Callback<SteamServerConnectFailure_t>.CreateGameServer(OnSteamServersConnectFailure);
            _callbackSteamServersDisconnected = Callback<SteamServersDisconnected_t>.CreateGameServer(OnSteamServersDisconnected);
            _callbackPolicyResponse = Callback<GSPolicyResponse_t>.CreateGameServer(OnPolicyResponse);
            _callbackGsAuthTicketResponse = Callback<ValidateAuthTicketResponse_t>.CreateGameServer(OnValidateAuthTicketResponse);
            _callbackP2PSessionRequest = Callback<P2PSessionRequest_t>.CreateGameServer(OnP2PSessionRequest);
            _callbackP2PSessionConnectFail = Callback<P2PSessionConnectFail_t>.CreateGameServer(OnP2PSessionConnectFail);

            _initialized = false;
            _connectedToSteam = false;
#if USE_GS_AUTH_API
            var eMode = EServerMode.eServerModeAuthenticationAndSecure;
#else
            var eMode = EServerMode.eServerModeNoAuthentication;
#endif
            _initialized = GameServer.Init(0, BrawlerAuthenticationPort, BrawlerServerPort,
                BrawlerMasterServerUpdaterPort, eMode, BrawlerServerVersion);

            if (!_initialized)
            {
                Debug.LogError("SteamGameServer_Init call Failed");
                return;
            }

            SteamGameServer.SetModDir("Brawler");
            SteamGameServer.SetProduct("Brawler");
            SteamGameServer.SetGameDescription("Multiplayer Brawler");

            SteamGameServer.LogOnAnonymous();

#if USE_GS_AUTH_API
            SteamGameServer.EnableHeartbeats(true);
#endif
        }
        
        private void Update()
        {
            if(!_initialized)
                return;
            
            GameServer.RunCallbacks();

            if (_connectedToSteam)
                SendUpdatedServerDetailsToSteam();
        }

        private void OnDisable()
        {
            SteamGameServer.EnableHeartbeats(false);
            SteamGameServer.LogOff();
            GameServer.Shutdown();
        }

        private void OnSteamServersConnected(SteamServersConnected_t logonSuccess)
        {
            Debug.Log("BrawlerServer connected to Steam successfully");
            _connectedToSteam = true;
            SendUpdatedServerDetailsToSteam();
        }

        private void OnSteamServersConnectFailure(SteamServerConnectFailure_t connectFailure)
        {
            _connectedToSteam = false;
            Debug.Log("BrawlerServer failed to connect to Steam");
        }

        private void OnSteamServersDisconnected(SteamServersDisconnected_t loggedOff)
        {
            _connectedToSteam = false;
            Debug.Log("BrawlerServer got logged out of Steam");
        }

        private void OnPolicyResponse(GSPolicyResponse_t policyResponse)
        {
#if USE_GS_AUTH_API
            Debug.Log(SteamGameServer.BSecure() ? "BrawlerServer is VAC Secure!" : "BrawlerServer is not VAC Secure!");
#endif
        }

        private void OnValidateAuthTicketResponse(ValidateAuthTicketResponse_t response)
        {
            Debug.Log("OnValidateAuthTicketResponse Called steamID: " + response.m_SteamID);
        }

        private void OnP2PSessionRequest(P2PSessionRequest_t callback)
        {
            Debug.Log("OnP2PSesssionRequest Called steamIDRemote: " + callback.m_steamIDRemote);
            SteamGameServerNetworking.AcceptP2PSessionWithUser(callback.m_steamIDRemote);
        }

        private void OnP2PSessionConnectFail(P2PSessionConnectFail_t callback)
        {
            Debug.Log("OnP2PSessionConnectFail Called steamIDRemote: " + callback.m_steamIDRemote);
        }

        private void SendUpdatedServerDetailsToSteam()
        {
            SteamGameServer.SetMaxPlayerCount(_maxPlayers);
            SteamGameServer.SetPasswordProtected(false);
            SteamGameServer.SetServerName(_serverName);
            SteamGameServer.SetMapName(_mapName);
        }
    }
}