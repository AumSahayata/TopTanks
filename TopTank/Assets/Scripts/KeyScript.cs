using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public event EventHandler OnPickupKey;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            OnPickupKey?.Invoke(this, EventArgs.Empty);
            //GameObject.FindAnyObjectByType<GameManager>().PickedUpKey();
        }
    }
}