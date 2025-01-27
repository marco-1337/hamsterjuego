using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float distance = 0;
    [SerializeField] Collider2D[] _colliders;
    
    public bool IsGrounded()
    {
        RaycastHit2D[] allTargets = Physics2D.RaycastAll(transform.position, Vector2.down, distance);
        int i = 0;
        bool grounded = false;
        while(i < allTargets.Length && !grounded)
        {
            int j = 0;
            while (j < _colliders.Length && allTargets[i].collider != _colliders[j]) j++;
            grounded = j == _colliders.Length;
            ++i;
        }
        return grounded;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    }
}
