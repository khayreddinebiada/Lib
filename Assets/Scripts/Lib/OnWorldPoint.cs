using UnityEngine;

namespace lib
{
    public class OnWorldPoint : MonoBehaviour
    {

        public enum NormalAxis
        {
            Vertical, Horizontal
        }

        [SerializeField]
        private float _offset = 0.0f;
        [SerializeField]
        private NormalAxis _normalAxis;

        private Plane _plane;
        private bool _onButton = false;
        public bool onButton
        {
            get { return _onButton; }
        }

        private Vector3 _position;
        public Vector3 position
        {
            get { return _position; }
        }

        private void Awake()
        {
            _onButton = false;

            switch (_normalAxis)
            {
                case NormalAxis.Vertical:
                    _plane = new Plane(Vector3.forward, -Vector3.forward * _offset);
                    break;
                case NormalAxis.Horizontal:
                    _plane = new Plane(Vector3.up, Vector3.up * _offset);
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RefreshPoint();
            }

            if (Input.GetMouseButtonDown(0))
            {
                _onButton = true;
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                _onButton = false;

            }
        }

        private void RefreshPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_plane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);

                _position = hitPoint;
            }
        }
    }
}