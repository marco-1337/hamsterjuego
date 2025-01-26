using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipaComponent : MonoBehaviour
{
    [SerializeField] Pipas contadorPipas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovementComponent>() != null)
        {
            //te chocas con jugador
            contadorPipas.numPipas++;
            Destroy(gameObject);
        }
    }
}
