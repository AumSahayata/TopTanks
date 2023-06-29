using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public event EventHandler ToStopInput;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private Text score;

    private int enemyKilled = 0;

    // -----For Key mode-----
    //[SerializeField] private Text remainingKeyCountTXT;

    //public int keyTarget;
    //private int keyCollected;

    private void Start() {
        score.text = enemyKilled.ToString();
        //remainingKeyCountTXT.text = (keyTarget - keyCollected).ToString();
    }

    private void LateUpdate() {
        if(GameObject.FindWithTag("Player") == null) {
            ToStopInput?.Invoke(this, EventArgs.Empty);
            
            if(player != null) {
                player.SetActive(false);
            }

            spawner.SetActive(false);
        }
    }

    //-----For key mode-----
    //public void PickedUpKey() {
    //    keyCollected++;
    //    remainingKeyCountTXT.text = (keyTarget - keyCollected).ToString();
    //}

    public void ScoreIncrement(string tankType) {
        if (tankType == "Chaser")
            enemyKilled++;
        else if (tankType == "Shooter")
            enemyKilled += 2;

        score.text = enemyKilled.ToString();
    }
}