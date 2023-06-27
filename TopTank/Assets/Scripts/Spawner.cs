using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject spawnTank;
    [SerializeField] private Transform[] spawnPointsArray;
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 3f;

    private void Start() {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            Transform spawnLoc = spawnPointsArray[Random.Range(0, spawnPointsArray.Length)];

            GameObject enemy = Instantiate(spawnTank,spawnLoc.position,transform.rotation);
            enemy.GetComponent<ChasingTankScript>().SetMoveSpeed(Random.Range(3, 6));
        }
    }
}