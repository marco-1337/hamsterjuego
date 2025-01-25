using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleElevatorPlatform : MonoBehaviour
{
    [SerializeField] private float _force = .0f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        MovementComponent playerMovement = collision.GetComponent<MovementComponent>();
        if(playerMovement != null)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * _force);
        }
    }
}
