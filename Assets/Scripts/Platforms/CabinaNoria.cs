using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinaNoria : MonoBehaviour
{
    [SerializeField] private GameObject objRef;
    private void LateUpdate()
    {
        transform.position = objRef.transform.position;
    }
}
