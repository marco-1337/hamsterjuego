using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _hamsterCenter; //El objeto center del hamster
    [SerializeField] private float _verticalOffset;

    private void Update()
    {
        float verticalTarget = _hamsterCenter.position.y;
        float horizontalTarget = _hamsterCenter.position.x;

        transform.position = 
            Vector3.Lerp(
                transform.position, 
                new Vector3(horizontalTarget,verticalTarget + _verticalOffset, -10), 
                Time.deltaTime * 4);
    }
}
