using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerThemeArea : MonoBehaviour
{

    [SerializeField]
    UnityEvent _playMusic1, _stopMusic1, _playMusic2, _stopMusic2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.velocity.y < 0)
        {
            _playMusic1.Invoke();
        }
        else if(collision.attachedRigidbody.velocity.y > 0)
        {
            _stopMusic1.Invoke();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.velocity.y < 0)
        {
            _stopMusic2.Invoke();
        }
        else if (collision.attachedRigidbody.velocity.y > 0)
        {
            _playMusic2.Invoke();
        }
    }

}
