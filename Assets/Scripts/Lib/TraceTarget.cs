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

    // Start is called before the first frame update
    private void Start()
    {
        _initDeltaPosition = transform.position - _target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isTrace)
        {
            Vector3 vec = _initDeltaPosition + _target.position;
            transform.position = new Vector3(
                (_traceOn.x) ? vec.x : transform.position.x,
                (_traceOn.y) ? vec.y : transform.position.y,
                (_traceOn.z) ? vec.z : transform.position.z
                );

        }
    }
}
