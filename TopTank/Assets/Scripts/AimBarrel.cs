using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBarrel : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform tankBody;
    private bool moveBarrel = false;
    public Vector2 pointerPos { get; set; }

    private void Start () {
        gameInput.OnBarrelAction += GameInput_OnBarrelAction;
    }

    private void GameInput_OnBarrelAction(object sender, System.EventArgs e) {
        moveBarrel = !moveBarrel;
    }

    private void Update() {

        if (moveBarrel) {
            pointerPos = gameInput.GetPointerInput();

            transform.up = (pointerPos - (Vector2)transform.position).normalized;
        }

    }

}