using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TraceAxis
{
    public bool x = true, y = true, z = true;
}

public class TraceTarget : MonoBehaviour
{
    [SerializeField]
    private bool _isTrace = false;

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
        _initDeltaPosition = transform.position - _target.position;
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

            if (_isSlerp)
                transform.position = Vector3.Slerp(transform.position, goPos, _movingSpeed * Time.fixedDeltaTime);
            else
                transform.position = goPos;

        }
    }
}
