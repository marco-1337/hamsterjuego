using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float distance = 0;
    [SerializeField] Collider2D myCollider;
    [SerializeField] PolygonCollider2D rocketCollider;
    
    public bool IsGrounded()
    {
        RaycastHit2D[] allTargets = Physics2D.RaycastAll(transform.position, Vector2.down, distance);
        int i = 0;
        bool grounded = false;
        while(i < allTargets.Length && !grounded)
        {
            if(allTargets[i].collider != myCollider && 
                allTargets[i].collider != rocketCollider) grounded = true;
            ++i;
        }
        return grounded;
    }

    public Vector2 SurfaceVector()
    {
        RaycastHit2D[] allTargets = Physics2D.RaycastAll(transform.position, Vector2.down, distance);
        int i = 0;

        while (i < allTargets.Length)
        {
            if (allTargets[i].collider != myCollider && allTargets[i].collider != rocketCollider)
            {
                return allTargets[i].collider.GetComponent<Transform>().right;
            }
            ++i;
        }

        return Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    }
}
