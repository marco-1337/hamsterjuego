using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipaComponent : MonoBehaviour
{
    [SerializeField] Pipas contadorPipas;
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MovementComponent>() != null)
        {
            //te xocas con jugado
            contadorPipas.numPipas++;
            Destroy(gameObject);
        }
    }
}
