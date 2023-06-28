using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public event EventHandler ToStopInput;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private Text remainingKeyCountTXT;

    public int keyTarget;
    private int keyCollected;

    private void Start() {
        remainingKeyCountTXT.text = (keyTarget - keyCollected).ToString();
    }

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
        remainingKeyCountTXT.text = (keyTarget - keyCollected).ToString();
    }

}