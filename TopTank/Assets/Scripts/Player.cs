using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        if(inputVector != Vector2.zero ) {
            transform.position += new Vector3(inputVector.x,inputVector.y,0) * 5f * Time.deltaTime;

            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, inputVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotate, 8f * Time.deltaTime);
        }
    }
}