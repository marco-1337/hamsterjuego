using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float distance = 0;
    [SerializeField] Collider2D myCollider, rocketCollider;
    public bool IsGrounded()
    {
        RaycastHit2D[] allTargets = Physics2D.RaycastAll(transform.position, Vector2.down, distance);
        int i = 0;
        bool grounded = false;
        while(i < allTargets.Length && !grounded)
        {
            if(allTargets[i].collider != myCollider && allTargets[i].collider != rocketCollider) grounded = true;
            ++i;
        }
        return grounded;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    }
}
