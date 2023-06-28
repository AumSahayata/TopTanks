using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public event EventHandler ToStopInput;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawner;

    public int keyTarget;
    private int keyCollected;


    private void LateUpdate() {
        if(GameObject.FindWithTag("Player") == null || keyCollected == keyTarget) {
            ToStopInput?.Invoke(this, EventArgs.Empty);
            
            if(player != null) {
                player.SetActive(false);
            }

            spawner.SetActive(false);
        }
    }

    public void PickedUpKey() {
        keyCollected++;
        print(keyCollected);
    }

}