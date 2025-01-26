using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerThemeArea : MonoBehaviour
{

    [SerializeField]
    UnityEvent _triggerEnter, _triggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a");
        _triggerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("b");
        _triggerExit.Invoke();
    }

}
