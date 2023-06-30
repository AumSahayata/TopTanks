using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    private GameInput gameInput;
    private void Awake() {
        gameInput = GameObject.FindAnyObjectByType<GameInput>();
    }
    public void Resume() {
        gameInput.pause = false;
        gameInput.Pause();
        gameObject.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameInput.pause = false;
        gameInput.Pause();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}