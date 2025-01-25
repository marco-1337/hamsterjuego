using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _hamsterCenter; //El objeto center del hamster
    [SerializeField] private GroundDetector _hamsterGroundDetector;
    [SerializeField] private float _verticalOffset;

    private float _previousVertcalTarget;

    private void Start()
    {
        _previousVertcalTarget = transform.position.y;
    }

    private void Update()
    {
        if(_hamsterGroundDetector.IsGrounded()) _previousVertcalTarget = _hamsterCenter.position.y;

        float horizontalTarget = _hamsterCenter.position.x;

        transform.position = Vector3.Lerp(transform.position, new Vector3(horizontalTarget, _previousVertcalTarget + _verticalOffset, -10), Time.deltaTime * 2);
    }
}
