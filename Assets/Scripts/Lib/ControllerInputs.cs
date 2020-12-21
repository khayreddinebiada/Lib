using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerInputs : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private static ControllerInputs _instance;
    public static ControllerInputs instance
    {
        get { return _instance; }
    }

    private bool _isClicked = false;
    public bool isClicked
    {
        get
        {
            if (_isClicked)
            {
                _isClicked = false;
                return true;
            }
            else
                return false;
        }
    }

    private bool _isOnDragging = false;
    public bool isOnDragging
    {
        get { return _isOnDragging; }
    }

    private bool _stop = false;
    private Vector2 _deltaDragging;
    public Vector2 deltaDragging
    {
        get { return _deltaDragging; }
    }

    private Vector2 _initPosition;

    private void Awake()
    {
        _instance = this;
    }
    private void Update()
    {
        CheckClick();
    }

    public void StopInputs()
    {
        _stop = true;
    }

    public void OnPointerClick(Vector2 position)
    {
        if (_stop || IgnoreClick())
            return;

        _isClicked = true;
    }

    private void CheckClick()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            _initPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Vector2.Distance(_initPosition, Input.mousePosition) == 0)
                OnPointerClick(Input.mousePosition);

            _initPosition = Vector2.zero;
        }
#else
            if (0 < Input.touchCount)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    _initPosition = Input.touches[0].position;
                }
                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    if (Vector2.Distance(_initPosition, Input.touches[0].position) == 0)
                    OnPointerClick(Input.touches[0].position);

                    _initPosition = Vector2.zero;
                }
            }
#endif
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_stop)
            return;

        _isOnDragging = true;
        _deltaDragging = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_stop)
        {
            _deltaDragging = Vector2.zero;
            return;
        }

        _deltaDragging = eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isOnDragging = false;
        _deltaDragging = Vector2.zero;
    }

    private bool IgnoreClick()
    {
        return false;
    }

    private bool IgnoreDrag()
    {
        return false;
    }
}
