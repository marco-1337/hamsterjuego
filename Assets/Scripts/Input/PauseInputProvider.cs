using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseInputProvider : MonoBehaviour
{
    [SerializeField] private InputActionReference _pauseInputActionReference;
    [SerializeField] private Pauser _pauser;

    private void Awake()
    {
        _pauseInputActionReference.action.performed += OnPauseInputDetected;
    }

    private void OnEnable()
    {
        _pauseInputActionReference.action.Enable();        
    }

    private void OnDisable()
    {
        _pauseInputActionReference.action.Disable();
    }

    private void OnDestroy()
    {
        _pauseInputActionReference.action.performed += OnPauseInputDetected;
    }

    private void OnPauseInputDetected(InputAction.CallbackContext obj) => _pauser.Pause();

}
