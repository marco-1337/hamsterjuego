using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPrueba : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveLeftInputActionReference;
    [SerializeField] private InputActionReference _moveRightInputActionReference;
    [SerializeField] private InputActionReference _rocketInputActionReference;

    private MovementComponent _movementComponent;
    private Impulsor _impulsor;

    private void Awake()
    {
        //Buscar componentes
        _movementComponent = GetComponent<MovementComponent>();
        _impulsor = GetComponent<Impulsor>();

        //Procesar input
        _moveLeftInputActionReference.action.performed += OnLeftInputRecieved;
        _moveRightInputActionReference.action.performed += OnRightInputRecieved;

        _moveLeftInputActionReference.action.canceled += OnLeftInputReleased;
        _moveRightInputActionReference.action.canceled += OnRightInputReleased;

        _rocketInputActionReference.action.performed += OnRocketInputRecieved;
        _rocketInputActionReference.action.canceled += OnRocketInputReleased;
    }


    private void OnEnable()
    {
        _moveLeftInputActionReference.action.Enable();
        _moveRightInputActionReference.action.Enable();
        _rocketInputActionReference.action.Enable();
    }

    private void OnDisable()
    {
        _moveLeftInputActionReference.action.Disable();
        _moveRightInputActionReference.action.Disable();
        _rocketInputActionReference.action.Disable();
    }

    private void OnDestroy()
    {
        _moveLeftInputActionReference.action.performed -= OnLeftInputRecieved;
        _moveRightInputActionReference.action.performed -= OnRightInputRecieved;

        _moveLeftInputActionReference.action.canceled -= OnLeftInputReleased;
        _moveRightInputActionReference.action.canceled -= OnRightInputReleased;

        _rocketInputActionReference.action.performed -= OnRocketInputRecieved;
        _rocketInputActionReference.action.canceled -= OnRocketInputReleased;
    }

    #region actions
    //Pulsar
    private void OnLeftInputRecieved(InputAction.CallbackContext obj) => setPlayerDirection(new Vector2(-1, 0));
    private void OnRightInputRecieved(InputAction.CallbackContext obj) => setPlayerDirection(new Vector2(1, 0));

    private void OnRocketInputRecieved(InputAction.CallbackContext obj) => _impulsor.Setimpulse(true);

    //Soltar
    private void OnLeftInputReleased(InputAction.CallbackContext obj) => _movementComponent.LeftKeyReleased();
    private void OnRightInputReleased(InputAction.CallbackContext obj) => _movementComponent.RightKeyReleased();
    private void OnRocketInputReleased(InputAction.CallbackContext obj) => _impulsor.SetImpulse(false);

    #endregion
    private void setPlayerDirection(Vector2 direction) => _movementComponent.SetDirection(direction);
}
