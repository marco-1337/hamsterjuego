using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region properties

    [SerializeField]
    private float _speed = 6.0f;

    [SerializeField]
    private float _maxSpeed = 10.0f;

    private Vector2 _direction = Vector2.zero;

    private Rigidbody2D _rb;
    #endregion

    #region methods
    public void setPlayerDirection(Vector2 dir)
    {
        _direction = dir;
    }

    public void rightKeyReleased()
    {
        if (_direction.x == 1.0)
            _direction.x = 0;
    }
    public void leftKeyReleased()
    {
        if (_direction.x == -1.0)
            _direction.x = 0;
    }
    #endregion


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if(_direction.x != 0)
        {
            _rb.AddForce(_direction * _speed);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed), 0); 
        }
    }
}
