using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyComponent : MonoBehaviour
{

    private bool _stick = true;

    void OnTriggerStay2D(Collider2D other) {

        MovementComponent janterMufmen = other.gameObject.GetComponent<MovementComponent>();

        MovementComponent mufmenParen = other.gameObject.GetComponentInParent<MovementComponent>();

        if (_stick)
        {
            if (janterMufmen != null)
            {
                Debug.Log(transform.up.normalized);
                ConstantForce2D janterGraviti = other.GetComponent<ConstantForce2D>();

                janterGraviti.force = transform.up.normalized * 300;

                janterMufmen.SetSticking(true);
            }
            else if (mufmenParen != null)
            {
                ConstantForce2D janterGraviti = other.GetComponentInParent<ConstantForce2D>();

                janterGraviti.force = transform.up.normalized * 300;

                mufmenParen.SetSticking(true);
            }
        }
    }

    
    void OnTriggerExit2D(Collider2D other) {
        
        MovementComponent janterMufmen = other.gameObject.GetComponent<MovementComponent>();

        MovementComponent mufmenParen = other.gameObject.GetComponentInParent<MovementComponent>();

        if (janterMufmen != null)
        {
            ConstantForce2D janterGraviti = other.gameObject.GetComponent<ConstantForce2D>();

            janterGraviti.force = Vector2.down * 300;

            _stick = true;

            janterMufmen.SetSticking(false);
        }

        else if (mufmenParen != null)
        {
            ConstantForce2D janterGraviti = other.gameObject.GetComponentInParent<ConstantForce2D>();
            
            janterGraviti.force = Vector2.down * 300;

            _stick = true;

            mufmenParen.SetSticking(false);
        }
    }

    public void Unstick()
    {
        _stick = false;
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
