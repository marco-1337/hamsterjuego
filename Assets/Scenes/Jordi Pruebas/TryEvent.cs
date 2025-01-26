using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TryEvent : MonoBehaviour
{
    [SerializeField] UnityEvent star;
    // Start is called before the first frame update
    void Start()
    {
        star.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
