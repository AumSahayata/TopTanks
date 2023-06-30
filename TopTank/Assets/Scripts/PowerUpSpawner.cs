using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    [SerializeField] private GameObject powerUp;
    [SerializeField] private Transform[] spawnPointsArray;
    [SerializeField] private int powerUPSpawnTime = 10;


    private void Start() {
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp() {

        yield return new WaitForSeconds(powerUPSpawnTime);
    
        Transform spawnLoc = spawnPointsArray[Random.Range(0,spawnPointsArray.Length)];

        GameObject spawnedpowerUp = Instantiate(powerUp, spawnLoc.position, spawnLoc.rotation);

        spawnedpowerUp.GetComponent<PowerUpScript>().OnPowerUp += PowerUpSpawner_OnPowerUp;

    }

    private void PowerUpSpawner_OnPowerUp(object sender, System.EventArgs e) {
        StartCoroutine(SpawnPowerUp());
    }
}