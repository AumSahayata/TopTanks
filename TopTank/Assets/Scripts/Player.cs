using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * 2f * Time.deltaTime;
        }
    }

}