using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class OnTriggerWin : MonoBehaviour
{
    [SerializeField] UnityEvent _audioEvent;
    [SerializeField] GameObject _victoryCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementComponent movementComponent = collision.GetComponent<MovementComponent>();
        if (movementComponent != null)
        {
            _victoryCanvas.SetActive(true);
            _audioEvent.Invoke();
        }
    }
}
