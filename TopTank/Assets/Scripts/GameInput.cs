using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public event EventHandler OnShoot;
    public event EventHandler OnBarrelAction;

    private Controls playerControl;

    private void Awake() {
        playerControl = new Controls();
        playerControl.Player.Enable();
        playerControl.Player.Shoot.performed += Shoot_performed;
        playerControl.Player.BarrelAction.performed += BarrelAction_performed;
    }

    private void BarrelAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnBarrelAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerControl.Player.Movement.ReadValue<Vector2>();
        if(inputVector == null ) {
            playerControl = new Controls();
            playerControl.Player.Enable();
        }

        inputVector.Normalize();
        return inputVector;
    }
    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnShoot?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetPointerInput() {
        Vector3 mousePos = playerControl.Player.Aim.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}