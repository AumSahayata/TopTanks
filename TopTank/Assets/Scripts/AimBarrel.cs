using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBarrel : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    public Vector2 pointerPos { get; set; }

    private void Update() {
        pointerPos = gameInput.GetPointerInput();

        transform.up = (pointerPos - (Vector2)transform.position).normalized;
    }

}