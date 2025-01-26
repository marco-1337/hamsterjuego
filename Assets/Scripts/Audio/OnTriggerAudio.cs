using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class OnTriggerAudio : MonoBehaviour
{
    [SerializeField] UnityEvent _audioEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementComponent movementComponent = collision.GetComponent<MovementComponent>();
        if(movementComponent != null) _audioEvent.Invoke();
    }
}
