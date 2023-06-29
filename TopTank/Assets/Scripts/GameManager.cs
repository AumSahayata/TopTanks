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
    [SerializeField] private int waitUntilDiffIncINSEC = 60;

    [Header("New timing for spawner on diffculty increase")]
    [Tooltip("New Minimum Spawn Time")]
    [SerializeField] private float[] newMinTimeArray;
    [Tooltip("New Maximum Spawn Time")]
    [SerializeField] private float[] newMaxTimerArray;

    private int enemyKilled = 0;
    private int minMaxArrayIndex = 0;

    // -----For Key mode-----
    //[SerializeField] private Text remainingKeyCountTXT;

    //public int keyTarget;
    //private int keyCollected;

    private void Start() {
        score.text = enemyKilled.ToString();
        StartCoroutine(DifficultyIncreased(newMinTimeArray[minMaxArrayIndex], newMaxTimerArray[minMaxArrayIndex]));
        //remainingKeyCountTXT.text = (keyTarget - keyCollected).ToString();
    }

    private void LateUpdate() {
        if(GameObject.FindWithTag("Player") == null) {
            ToStopInput?.Invoke(this, EventArgs.Empty);
            
            if(player != null) {
                player.SetActive(false);
            }

            spawner.SetActive(false);
            StopAllCoroutines();
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

    IEnumerator DifficultyIncreased(float newMin,float newMax) {
        yield return new WaitForSeconds(waitUntilDiffIncINSEC);

        spawner.GetComponent<Spawner>().SetNewMinMaxSpawnTime(newMin,newMax);

        if (minMaxArrayIndex < newMaxTimerArray.Length - 1)
            minMaxArrayIndex++;

        StartCoroutine(DifficultyIncreased(newMinTimeArray[minMaxArrayIndex], newMaxTimerArray[minMaxArrayIndex]));
    }
}