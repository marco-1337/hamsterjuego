using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float _distance = 0;
    [SerializeField] int _rays = 1;
    [SerializeField] float _width = 1f;

    private LayerMask _groundMask;

    private void Start()
    {
        _groundMask = LayerMask.GetMask("Ground");
    }

    public bool IsGrounded()
    {
        float unit = _width / _rays;
        int i = 0;
        while (i <= _rays && !(bool)Physics2D.Raycast((new Vector2(transform.position.x - _width / 2 + unit * i, transform.position.y)), Vector2.down, _distance, _groundMask)) ++i;
        return i<= _rays;
    }

    private void OnDrawGizmos()
    {
        float unit = _width / _rays;
        for(int i = 0; i <= _rays; ++i) Debug.DrawRay(new Vector2(transform.position.x - (_width / 2) + unit * i, transform.position.y), Vector2.down * _distance, Color.red);
    }
}
