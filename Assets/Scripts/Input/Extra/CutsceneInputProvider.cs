using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CutsceneInputProvider : MonoBehaviour
{
    [SerializeField] private InputActionReference _skipInputActionReference;
    [SerializeField] private CinematicManager _cinematic;

    private void Awake()
    {
        _skipInputActionReference.action.performed += OnSkipInputDetected;
    }

    private void OnEnable()
    {
        _skipInputActionReference.action.Enable();
    }

    private void OnDisable()
    {
        _skipInputActionReference.action.Disable();
    }

    private void OnDestroy()
    {
        _skipInputActionReference.action.performed += OnSkipInputDetected;
    }

    private void OnSkipInputDetected(InputAction.CallbackContext obj) => _cinematic.SkipCutscene();
}
