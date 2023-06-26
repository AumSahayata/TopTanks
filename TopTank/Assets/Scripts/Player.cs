using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject barrel;

    private void Update() {
        HandleMovement();
        HandleAim();
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        if(inputVector != Vector2.zero ) {
            transform.position += new Vector3(inputVector.x,inputVector.y,0) * 5f * Time.deltaTime;

            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, inputVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotate, 8f * Time.deltaTime);
        }
    }

    private void HandleAim() {
        Vector2 aimVector = gameInput.GetAimVectorNormalized();

        if(aimVector != Vector2.zero) {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, aimVector);
            barrel.transform.rotation = Quaternion.Slerp(barrel.transform.rotation, toRotate, 10f * Time.deltaTime);
        }
    }
}