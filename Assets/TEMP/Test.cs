using Brawler.Characters;
using Brawler.CustomInput;
using Brawler.Extentions;
using Brawler.GameManagement;
using Brawler.GameSettings;
using Brawler.LevelManagment;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    private CharacterManager _charManager;
    private GameManager Gm;
    private Character p1;
    private JoyStickButton _joystick1BackButton;

    void Start()
    {
        _charManager  = CharacterManager.Instance;
        Gm = GameManager.Instance;

        p1 = _charManager.GetCharacter("Fighter A");
        _joystick1BackButton = new JoyStickButton(JoyStickButtons.Joystick1Back, "Back");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Gm.AddPlayer(new GamePlayer(p1, default(PlayerControlsProfile)), SelectingForPlayer.Player1);
            Gm.AddPlayer(new GamePlayer(_charManager.GetCharacter("Fighter B"), default(PlayerControlsProfile)), SelectingForPlayer.Player2);
            Gm.StartMatch(LevelManager.Instance.GetRandomLevel());
        }
    }
}