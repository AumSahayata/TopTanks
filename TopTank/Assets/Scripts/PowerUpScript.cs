using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    public event EventHandler OnPowerUp;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            OnPowerUp?.Invoke(this, EventArgs.Empty);
        }
    }
}