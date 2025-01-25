using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region properties

    [SerializeField]
    private float _speed = 4.0f;

    [SerializeField]
    private float _maxSpeed = 10.0f;

    private Vector2 _moveDir = Vector2.zero;

    private Rigidbody2D _rb;
    private Transform _transform;
    private SpriteRenderer _renderer;
    private GroundDetector _groundDetector;
    #endregion

    #region methods
    public void SetDirection(Vector2 dir)
    {
        _moveDir = dir;
    }

    public void RightKeyReleased()
    {
        if (_moveDir.x == 1.0)
            _moveDir.x = 0;
    }
    public void LeftKeyReleased()
    {
        if (_moveDir.x == -1.0)
            _moveDir.x = 0;
    }
    #endregion


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
        _transform = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();
        _groundDetector = GetComponent<GroundDetector>();

    }

    void FixedUpdate()
    {
        if(_moveDir.x != 0)
        {
            Vector2 forceDir = _groundDetector.SurfaceVector().Abs();
            Vector2 forcePosition = new Vector2(_transform.position.x, _transform.position.y + _renderer.size.y / 4);
            if(forceDir != Vector2.zero) 
                _rb.AddForceAtPosition(_moveDir * forceDir * _speed, forcePosition);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed), _rb.velocity.y); 
        }
    }
}
