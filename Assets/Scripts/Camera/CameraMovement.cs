using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private float _verticalOffset;

    private float _previousVertcalTarget;

    private void Start()
    {
        _previousVertcalTarget = transform.position.y;
    }

    private void Update()
    {
        if(_groundDetector.IsGrounded()) _previousVertcalTarget = _targetTransform.position.y;

        float horizontalTarget = _targetTransform.position.x;

        transform.position = Vector2.Lerp(transform.position, new Vector2(horizontalTarget, _previousVertcalTarget + _verticalOffset), Time.deltaTime);
    }
}
