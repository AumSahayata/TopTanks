using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public event EventHandler ToStopInput;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject playingCanvas;
    [SerializeField] private GameObject gameoverCanvas;
    [SerializeField] private Text[] scoreArray;
    [SerializeField] private Text highscore;
    [SerializeField] private int waitUntilDiffIncINSEC = 60;

    [Header("New timing for spawner on diffculty increase")]
    [Tooltip("New Minimum Spawn Time")]
    [SerializeField] private float[] newMinTimeArray;
    [Tooltip("New Maximum Spawn Time")]
    [SerializeField] private float[] newMaxTimerArray;

    private int scoreCounter = 0;
    private int minMaxArrayIndex = 0;
    private GameObject messagePanel;

    private void Start() {

        playingCanvas.SetActive(true);
        gameoverCanvas.SetActive(false);

        scoreArray[0].text = scoreCounter.ToString();
        scoreArray[1].text = scoreCounter.ToString();
        StartCoroutine(DifficultyIncreased(newMinTimeArray[minMaxArrayIndex], newMaxTimerArray[minMaxArrayIndex]));
    }

    private void LateUpdate() {
        if(GameObject.FindWithTag("Player") == null) {
            ToStopInput?.Invoke(this, EventArgs.Empty);
            
            if(player != null) {
                player.SetActive(false);
            }

            spawner.SetActive(false);
            highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
            StopAllCoroutines();
            playingCanvas.SetActive(false);
            gameoverCanvas.SetActive(true);
        }
    }

    public void ScoreIncrement(string tankType) {
        if (tankType == "Chaser")
            scoreCounter++;
        else if (tankType == "Shooter")
            scoreCounter += 2;

        scoreArray[0].text = scoreCounter.ToString();
        scoreArray[1].text = scoreCounter.ToString();

        if(scoreCounter > PlayerPrefs.GetInt("highscore",0)) {
            PlayerPrefs.SetInt("highscore", scoreCounter);
            PlayerPrefs.Save();
        }
    }

    IEnumerator DifficultyMessage() {
        messagePanel = playingCanvas.transform.Find("MessagePanel").gameObject;
        messagePanel.SetActive(true);

        yield return new WaitForSeconds(2);
        messagePanel.SetActive(false);
    }
    IEnumerator DifficultyIncreased(float newMin,float newMax) {
        yield return new WaitForSeconds(waitUntilDiffIncINSEC);

        spawner.GetComponent<Spawner>().SetNewMinMaxSpawnTime(newMin,newMax);

        if (minMaxArrayIndex < newMaxTimerArray.Length - 1)
            minMaxArrayIndex++;

        StartCoroutine(DifficultyIncreased(newMinTimeArray[minMaxArrayIndex], newMaxTimerArray[minMaxArrayIndex]));
        StartCoroutine(DifficultyMessage());
    }
}