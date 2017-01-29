using System.Collections.Generic;
using System.Linq;
using Brawler.GameSettings;
using UnityEngine;

namespace Brawler.GamePlay
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private float _boundingBoxPadding = 2f;
        [SerializeField] private float _minimumOrthographicSize = 8f;
        [SerializeField] private float _zoomSpeed = 20f;

        private Camera _camera;
        private Transform[] _targets;
        
        public void Init(List<GamePlayer> gamePlayers)
        {
            _camera = GetComponentInChildren<Camera>();
            _targets = gamePlayers.Select(gamePlayer => gamePlayer.Character.transform).ToArray();
        }

        private void LateUpdate()
        {
            var boundingBox = CalculateTargetsBoundingBox();
            transform.position = CalculateCameraPosition(boundingBox);
            _camera.orthographicSize = CalculateOrthographicSize(boundingBox);
        }

        private Rect CalculateTargetsBoundingBox()
        {
            var minX = Mathf.Infinity;
            var maxX = Mathf.NegativeInfinity;
            var minY = Mathf.Infinity;
            var maxY = Mathf.NegativeInfinity;

            foreach (var target in _targets)
            {
                var position = target.position;

                minX = Mathf.Min(minX, position.x);
                minY = Mathf.Min(minY, position.y);
                maxX = Mathf.Max(maxX, position.x);
                maxY = Mathf.Max(maxY, position.y);
            }

            return Rect.MinMaxRect(minX - _boundingBoxPadding, maxY + _boundingBoxPadding, maxX + _boundingBoxPadding, minY - _boundingBoxPadding);
        }

        private Vector3 CalculateCameraPosition(Rect boundingBox)
        {
            var boundingBoxCenter = boundingBox.center;

            return new Vector3(boundingBoxCenter.x, boundingBoxCenter.y, _camera.transform.position.z);
        }

        private float CalculateOrthographicSize(Rect boundingBox)
        {
            var topRight = new Vector3(boundingBox.x + boundingBox.width, boundingBox.y, 0f);
            var topRightAsViewport = _camera.WorldToViewportPoint(topRight);

            var orthographicSize = topRightAsViewport.x >= topRightAsViewport.y
                ? Mathf.Abs(boundingBox.width)/_camera.aspect/2f
                : Mathf.Abs(boundingBox.height)/2f;

            return Mathf.Clamp(Mathf.Lerp(_camera.orthographicSize, orthographicSize, Time.deltaTime * _zoomSpeed), _minimumOrthographicSize, Mathf.Infinity);
        }
    }
}