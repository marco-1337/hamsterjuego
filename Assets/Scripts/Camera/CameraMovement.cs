using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _hamsterCenter; //El objeto center del hamster
    [SerializeField] private GroundDetector _hamsterGroundDetector;
    [SerializeField] private float _verticalOffset;

    private float _previousVertcalTarget;
    private bool _keepChasing;

    private void Start()
    {
        _previousVertcalTarget = transform.position.y;
        _keepChasing = false;
    }

    private void Update()
    {
        if(_hamsterGroundDetector.IsGrounded() || _keepChasing) _previousVertcalTarget = _hamsterCenter.position.y;
        else if (!_keepChasing) StartCoroutine(KeepChasingCoroutine());

        float horizontalTarget = _hamsterCenter.position.x;

        transform.position = Vector3.Lerp(transform.position, new Vector3(horizontalTarget, _previousVertcalTarget + _verticalOffset, -10), Time.deltaTime * 2);
    }

    private IEnumerator KeepChasingCoroutine()
    {
        _keepChasing = true;
        yield return new WaitForSeconds(0.5f);
        _keepChasing = false;
    }
}
