using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noria : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5;

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationSpeed*Time.deltaTime));
    }
}
