using UnityEngine;

namespace game.lib
{
    public class RotateObject : MonoBehaviour
    {
        public enum TransformType { Global, Local }

        [SerializeField]
        private bool _allowRotate;
        public bool allowRotate
        {
            get { return _allowRotate; }
            set { _allowRotate = value; }
        }

        [SerializeField]
        private TransformType _transformType;

        [SerializeField]
        private float _speed = 10;

        [SerializeField]
        private Vector3 _axis = Vector3.up;

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (!_allowRotate)
                return;

            if (_transformType == TransformType.Global)
                transform.eulerAngles += _axis * _speed * Time.fixedDeltaTime;
            else
                transform.Rotate(_axis, _speed * Time.fixedDeltaTime);
        }
    }
}