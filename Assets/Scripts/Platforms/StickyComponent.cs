using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyComponent : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other) {
        
        MovementComponent janterMufmen = other.gameObject.GetComponent<MovementComponent>();

        if (janterMufmen != null)
        {
            Rigidbody2D janterRigibodi = other.gameObject.GetComponent<Rigidbody2D>();

            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
