using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float distance = 0;

    private LayerMask _groundMask;

    private void Start()
    {
        _groundMask = LayerMask.GetMask("Ground");
    }

    public bool IsGrounded() => (bool)Physics2D.Raycast(transform.position, Vector2.down, distance, _groundMask);

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    }
}
