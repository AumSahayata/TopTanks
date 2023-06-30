using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    
    public void Playagain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MapSelection() {
        SceneManager.LoadScene("MapSelection");
    }

    public void Exit() { 
        Application.Quit();
    }
}