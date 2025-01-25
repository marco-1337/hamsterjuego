using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorGuardado : MonoBehaviour
{
    [SerializeField] private Guardado guardado;
    [SerializeField] private Pipas pipas;
    // Start is called before the first frame update
    void Start()
    {
        if(guardado._savedPlayerTransform != null)
        {
            transform.position = guardado._savedPlayerTransform.position;
            transform.rotation = guardado._savedPlayerTransform.rotation;

            pipas.numPipas = guardado._savedPipas;
        }
        
    }
}
