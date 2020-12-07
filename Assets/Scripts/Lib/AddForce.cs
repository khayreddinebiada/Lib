using UnityEngine;

namespace game.target
{
    [RequireComponent(typeof(Rigidbody))]
    public class AddForce : MonoBehaviour
    {
        [SerializeField]
        private bool _randomForce = false;
        [SerializeField]
        private Vector3 _minRange;
        [SerializeField]
        private Vector3 _maxRange;
        [SerializeField]
        private float _forceAmount;
        [SerializeField]
        private ForceMode _forceMode = ForceMode.Force;

        [SerializeField]
        private Vector3 _hitVelocity;

        [SerializeField]
        private bool _byRandomTorque = false;
        [SerializeField]
        private float _torqueValue;
        [SerializeField]
        private Vector3 _forceTorque;


        private Rigidbody _rigidbody;

        // Start is called before the first frame update
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnAddForce()
        {
            if (!_randomForce)
                _rigidbody.AddForce(_hitVelocity * _forceAmount);
            else
                _rigidbody.AddForce((new Vector3(Random.Range(_minRange.x, _maxRange.x), Random.Range(_minRange.y, _maxRange.y), Random.Range(_minRange.z, _maxRange.z))) * _forceAmount);
        }

        public void OnAddTorque()
        {
            if (_byRandomTorque)
                _rigidbody.AddTorque(new Vector3(Random.Range(-1, 1), Random.Range(0.5f, 1), Random.Range(0.5f, 1)) * _torqueValue);
            else
                _rigidbody.AddTorque(_forceTorque * _torqueValue);
        }

    }
}