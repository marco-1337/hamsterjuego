using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorGuardado : MonoBehaviour
{
    [SerializeField] private Pipas pipas;
    // Start is called before the first frame update
    void Start()
    {
        pipas.numPipas = 0;
        
    }
}
