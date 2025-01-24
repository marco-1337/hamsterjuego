using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region properties

    [SerializeField]
    private float _speed = 4.0f;

    [SerializeField]
    private float _maxSpeed = 10.0f;

    private Vector2 _direction = Vector2.zero;
    private Vector2 _forcePosition;

    private Rigidbody2D _rb;
    private Transform _transform;
    private SpriteRenderer _renderer;
    #endregion

    #region methods
    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    public void RightKeyReleased()
    {
        if (_direction.x == 1.0)
            _direction.x = 0;
    }
    public void LeftKeyReleased()
    {
        if (_direction.x == -1.0)
            _direction.x = 0;
    }
    #endregion


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
        _transform = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();

        _forcePosition = new Vector2(_transform.position.x, _transform.position.y + _renderer.size.y / 4) ;
    }

    void Update()
    {
        Debug.Log(_rb.velocity.x);
        if(_direction.x != 0)
        {
            _rb.AddForceAtPosition(_direction * _speed, _forcePosition);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed), 0); 
        }
    }
}
