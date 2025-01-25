using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulsor : MonoBehaviour
{
    [SerializeField]
    float _force = 1;
    [SerializeField]
    float _impulseTime = 1.0f;
    Transform _transform;

    Rigidbody2D _myRigidbody;
    [SerializeField]
    bool _isJumping = false, _haveFuel = true;
    float _actualFuelTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _myRigidbody = GetComponentInParent<Rigidbody2D>();
        Debug.Log(_myRigidbody);
    }

    public void SetImpulse(bool isImpulsing)
    {
        _isJumping = isImpulsing;
    }

    private void Impulse()
    {
        _myRigidbody.AddForce(new Vector2(_transform.up.x, _transform.up.y).normalized*_force);
    }
    // Update is called once per frame
    void Update()
    {
        if(_isJumping && _haveFuel)
        {
            Impulse();

            _actualFuelTime += Time.deltaTime;
            _haveFuel = _impulseTime > _actualFuelTime;
        }
        else if(!_haveFuel)
        {
            _isJumping = false;
            _actualFuelTime = 0.0f;
            _haveFuel = true;
        }
    }
}
