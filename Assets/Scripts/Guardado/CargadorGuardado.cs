using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorGuardado : MonoBehaviour
{
    [SerializeField] private Guardado guardado;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = guardado._savedPlayerTransform.position;
        transform.rotation = guardado._savedPlayerTransform.rotation;
    }
}
