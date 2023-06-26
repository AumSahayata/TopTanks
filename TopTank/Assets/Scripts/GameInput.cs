using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    private Controls playerControl;

    private void Awake() {
        playerControl = new Controls();
        playerControl.Player.Enable();
    }


    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerControl.Player.Movement.ReadValue<Vector2>();
        inputVector.Normalize();
        return inputVector;
    }
}