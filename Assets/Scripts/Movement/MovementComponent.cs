using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region properties

    [SerializeField]
    private float _strength = 200.0f;
    [SerializeField]
    private float _airStrength = 100.0f;

    [SerializeField]
    private float _maxSpeed = 400.0f;

    [SerializeField]
    private float _threshold = 1.0f;

    private Vector2 _moveDir = Vector2.zero;

    private Rigidbody2D _rb;
    private Transform _transform;
    private SpriteRenderer _renderer;
    private GroundDetector _groundDetector;
    private ConstantForce2D _constantForce;

    private bool _isSticking = false;

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

    public bool IsMoving()
    {
        return _rb.velocity.magnitude > _threshold;
    }
    #endregion


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
        _transform = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();
        _groundDetector = GetComponent<GroundDetector>();
        _constantForce = GetComponent<ConstantForce2D>();
    }

    void FixedUpdate()
    {
        if(_moveDir.x != 0)
        {
            Vector2 forceDir = _constantForce.force.normalized;
            (forceDir.x, forceDir.y) = (forceDir.y, forceDir.x);

            forceDir.x *= -1;

            forceDir = forceDir.Abs();

            Vector2 forcePosition = new Vector2(_transform.position.x, _transform.position.y + _renderer.size.y / 4);
            //if(forceDir != Vector2.zero || _isSticking) 
            if(_groundDetector.IsGrounded())
                _rb.AddForceAtPosition(_moveDir * forceDir * _strength, forcePosition);
            else _rb.AddForceAtPosition(_moveDir * forceDir * _airStrength, forcePosition);

            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed), _rb.velocity.y); 
        }
    }

    public void SetSticking(bool s) => _isSticking = s;
}
