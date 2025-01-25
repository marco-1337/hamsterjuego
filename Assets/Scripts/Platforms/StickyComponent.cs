using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyComponent : MonoBehaviour
{

    void OnCollisionStay2D(Collision2D other) {
        
        MovementComponent janterMufmen = other.gameObject.GetComponent<MovementComponent>();

        if (janterMufmen != null)
        {
            ConstantForce2D janterGraviti = other.gameObject.GetComponent<ConstantForce2D>();

            Debug.Log("AAAAA");

            janterGraviti.force = other.contacts[0].normal * 400;

            janterMufmen.SetSticking(true);
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        
        MovementComponent janterMufmen = other.gameObject.GetComponent<MovementComponent>();

        if (janterMufmen != null)
        {
            ConstantForce2D janterGraviti = other.gameObject.GetComponent<ConstantForce2D>();
            Debug.Log("BBBBB");
            janterGraviti.force = Vector2.down * 200;

            janterMufmen.SetSticking(true);
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
