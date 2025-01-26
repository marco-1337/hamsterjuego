using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputProvider : MonoBehaviour
{
    [SerializeField] private CameraFollowMovement _cameraFollow;
    [SerializeField] private CameraMoveOnInput _cameraMove;

    [SerializeField] private InputActionReference _cameraInputActionReference;

    private void Awake()
    {
        _cameraInputActionReference.action.performed += OnInputRecieved;
        _cameraInputActionReference.action.canceled += OnInputStop;
    }
    private void OnEnable()
    {
        _cameraInputActionReference.action.Enable();
    }
    private void OnDisable()
    {
        _cameraInputActionReference.action.Enable();
    }
    private void OnDestroy()
    {
        _cameraInputActionReference.action.performed -= OnInputRecieved;
        _cameraInputActionReference.action.canceled -= OnInputStop;
    }

    private void OnInputRecieved(InputAction.CallbackContext obj)
    {
        _cameraFollow.enabled = false;
        _cameraMove.Move(obj.ReadValue<Vector2>());
    }

    private void OnInputStop(InputAction.CallbackContext obj)
    {
        _cameraMove.StopMoving();
        _cameraFollow.enabled = true;
    }
}
