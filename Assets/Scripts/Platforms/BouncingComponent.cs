using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BouncingComponent : MonoBehaviour
{

    [SerializeField]
    private float _potensia = 1.0f; 

    void OnCollisionEnter2D(Collision2D other) {
        
        MovementComponent janterMufmen = other.gameObject.GetComponent<MovementComponent>();

        if (janterMufmen != null)
        {
            Rigidbody2D janterRigibodi = other.gameObject.GetComponent<Rigidbody2D>();

            Debug.Log(other.contacts[0].normal*-10000*_potensia);
            Debug.DrawRay(other.contacts[0].point, other.contacts[0].normal*-1, Color.green, 10f);

            janterRigibodi.AddForce(other.contacts[0].normal*-10000*_potensia);
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
