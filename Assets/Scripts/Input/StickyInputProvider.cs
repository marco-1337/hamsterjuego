using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StickyInputProvider : MonoBehaviour
{
    [SerializeField] InputActionReference _rocketInputActionReference;
    [SerializeField] StickyComponent _sticky;

    private void Awake()
    {
        _rocketInputActionReference.action.performed += OnRocketInputRecieved;
    }

    private void OnEnable()
    {
        _rocketInputActionReference.action.Enable();
    }

    private void OnDisable()
    {
        _rocketInputActionReference.action.Disable();
    }

    private void OnDestroy()
    {
        _rocketInputActionReference.action.performed -= OnRocketInputRecieved;
    }

    private void OnRocketInputRecieved(InputAction.CallbackContext obj) => /*_sticky.Unstick();*/ Debug.Log("Borra esto");
}
