using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game.lib
{
    public class Movement : MonoBehaviour
    {
        public enum MovingType
        {
            Transform, Position, Direction
        }

        public enum World
        {
            Global, Local
        }

        [SerializeField]
        private bool _onStart = false;

        [SerializeField]
        private float _movingSpeed = 10;

        [SerializeField]
        private MovingType _movingType;

        [SerializeField]
        private World _world;

        [Header("Go To")]
        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Vector3 _byPositionOrDirection;

        private bool _isMoving = false;

        // Start is called before the first frame update
        private void Start()
        {
            if (_movingType == MovingType.Transform && _transform == null)
                Debug.LogError("Please add the transfrom it is empty");

            if (_onStart)
                StartMove();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_isMoving)
                return;

            switch (_movingType)
            {
                case MovingType.Transform:
                    GoToTransform();
                    break;
                case MovingType.Position:
                    GoToPosition();
                    break;
                case MovingType.Direction:
                    GoToDirection();
                    break;
            }
        }

        private void GoToTransform()
        {
            transform.position = Vector3.MoveTowards(transform.position, _transform.position, _movingSpeed * Time.deltaTime);

            /// Check Stop Moving...
            if (Vector3.Distance(transform.position, _transform.position) <= 0.05f)
            {
                transform.position = _transform.position;
                _isMoving = false;
            }
        }

        private void GoToPosition()
        {
            if (_world == World.Global)
            {
                transform.position = Vector3.MoveTowards(transform.position, _byPositionOrDirection, _movingSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, _byPositionOrDirection) <= 0.05f)
                {
                    transform.position = _byPositionOrDirection;
                    _isMoving = false;
                }
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, _byPositionOrDirection, _movingSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.localPosition, _byPositionOrDirection) <= 0.05f)
                {
                    transform.localPosition = _byPositionOrDirection;
                    _isMoving = false;
                }
            }
        }

        private void GoToDirection()
        {
            if (_world == World.Global)
                transform.position += _byPositionOrDirection * _movingSpeed * Time.deltaTime;
            else
                transform.position += 
                    (
                    transform.right * _byPositionOrDirection.x +
                    transform.up * _byPositionOrDirection.y +
                    transform.forward * _byPositionOrDirection.z
                    ) *
                    _movingSpeed * Time.deltaTime;
        }

        public void StartMove()
        {
            if (_isMoving == true)
                return;

            _isMoving = true;

        }
    }
}
