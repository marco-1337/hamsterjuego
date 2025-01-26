using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Impulsor : MonoBehaviour
{
    [SerializeField]
    private GroundDetector _groundDetector;
    [SerializeField]
    private UI_Fuel _UI_fuel;// es la barra de energia 
    [SerializeField]
    float _force = 1;
    [SerializeField]
    float _impulseTime = 1.0f;
    Transform _transform;
    Rigidbody2D _myRigidbody;
    [SerializeField]
    bool _isJumping = false, _haveFuel = true;
    [SerializeField]
    private GameObject _fuegote;

    float _actualFuelTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _myRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    public void SetImpulse(bool isImpulsing)
    {
        _isJumping = isImpulsing;
    }

    private void Impulse()
    {
        _myRigidbody.AddForce(new Vector2(_transform.up.x, _transform.up.y).normalized * _force);
    }

    private void EnableFire(bool isPropelling)
    {
        if(_fuegote.activeSelf != isPropelling)
            _fuegote.SetActive(isPropelling);
    }
    // Update is called once per frame
    void Update()
    {
        //if (_isJumping && _haveFuel)
        //{
        //    Debug.Log($"{_actualFuelTime}, {_impulseTime}");
        //    _actualFuelTime += Time.deltaTime;
        //    //Debug.Log(_actualFuelTime);
        //    _haveFuel = _impulseTime > _actualFuelTime;
        //    if(_UI_fuel != null) _UI_fuel.SetFuelBar(_actualFuelTime);

        //    EnableFire(true);
        //}
        //else if (!_haveFuel)
        //{
        //    if (_UI_fuel != null) _UI_fuel.Overheated(true);
        //}
        //if (_groundDetector.IsGrounded())
        //{
        //    Debug.Log(_actualFuelTime);
        //    _actualFuelTime = .0f;
        //    _haveFuel = true;
        //    if (_UI_fuel != null) _UI_fuel.SetFuelBar(_actualFuelTime);
        //    if (_UI_fuel != null) _UI_fuel.Overheated(false);
        //}
        //if(!_haveFuel || !_isJumping)
        //    EnableFire(false);
    }
    private void FixedUpdate()
    {
        if (_isJumping && _haveFuel)
        {
            Impulse();

            _actualFuelTime += Time.fixedDeltaTime;
            _haveFuel = _impulseTime > _actualFuelTime;
            if (_UI_fuel != null) _UI_fuel.SetFuelBar(_actualFuelTime);

            EnableFire(true);
        }
        else if (!_haveFuel)
        {
            if (_UI_fuel != null) _UI_fuel.Overheated(true);
        }
        if (_groundDetector.IsGrounded())
        {
            Debug.Log("grounded");
            _actualFuelTime = .0f;
            _haveFuel = true;
            if (_UI_fuel != null) _UI_fuel.SetFuelBar(_actualFuelTime);
            if (_UI_fuel != null) _UI_fuel.Overheated(false);
        }
        if (!_haveFuel || !_isJumping)
            EnableFire(false);
    }
}
