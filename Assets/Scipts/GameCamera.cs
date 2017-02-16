using Brawler.Characters;
using UnityEngine;

namespace Brawler.GamePlay
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private float _boundingBoxPadding = 2f;
        [SerializeField] private float _minimumOrthographicSize = 8f;
        [SerializeField] private float _zoomSpeed = 20f;

        private Camera _camera;
        private Character _player1;
        private Character _player2;
        
        public void Init(Character player1, Character player2)
        {
            _camera = GetComponentInChildren<Camera>();
            _player1 = player1;
            _player2 = player2;
        }
    }
}