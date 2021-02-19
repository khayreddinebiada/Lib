using UnityEngine;

namespace lib
{
    [System.Serializable]
    public class TraceAxis
    {
        public bool x = true;
        [SerializeField]
        private Vector2 _borderX = new Vector2(-Mathf.Infinity, Mathf.Infinity);

        public bool y = true;
        [SerializeField]
        private Vector2 _borderY = new Vector2(-Mathf.Infinity, Mathf.Infinity);

        public bool z = true;
        [SerializeField]
        private Vector2 _borderZ = new Vector2(-Mathf.Infinity, Mathf.Infinity);

        public Vector3 ClampVector(Vector3 vector)
        {
            return new Vector3
                (
                Mathf.Clamp(vector.x, _borderX.x, _borderX.y),
                Mathf.Clamp(vector.y, _borderY.x, _borderY.y),
                Mathf.Clamp(vector.z, _borderZ.x, _borderZ.y)
                );
        }
    }

    public class TraceTarget : MonoBehaviour
    {
        [SerializeField]
        private bool _isTrace = false;

        [SerializeField]
        private bool _startingPosition = true;
        [SerializeField]
        private Transform _target;
        private Vector3 _initDeltaPosition;


        [SerializeField]
        private TraceAxis _traceOn;

        [SerializeField]
        private bool _isSlerp = false;
        [SerializeField]
        private float _movingSpeed = 10;

        // Start is called before the first frame update
        private void Start()
        {
            if (_startingPosition)
                _initDeltaPosition = transform.position - _target.position;
            else
                _initDeltaPosition = Vector3.zero;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (_isTrace)
            {
                Vector3 vec = _initDeltaPosition + _target.position;
                Vector3 goPos = new Vector3(
                    (_traceOn.x) ? vec.x : transform.position.x,
                    (_traceOn.y) ? vec.y : transform.position.y,
                    (_traceOn.z) ? vec.z : transform.position.z
                    );

                goPos = _traceOn.ClampVector(goPos);

                if (_isSlerp)
                    transform.position = Vector3.Slerp(transform.position, goPos, _movingSpeed * Time.fixedDeltaTime);
                else
                    transform.position = goPos;

            }
        }
    }
}