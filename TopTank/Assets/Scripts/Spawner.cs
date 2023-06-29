using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject[] spawnTankArray;
    [SerializeField] private Transform[] spawnPointsArray;
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 3f;
    [SerializeField] private GameObject spawnAnimation;

    private void Start() {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            Transform spawnLoc = spawnPointsArray[Random.Range(0,spawnPointsArray.Length)];
            GameObject animationSpawned= Instantiate(spawnAnimation,spawnLoc.position,spawnLoc.rotation);

            yield return new WaitForSeconds(2);

            GameObject spawnTank = spawnTankArray[Random.Range(0,spawnTankArray.Length)];
            GameObject enemy = Instantiate(spawnTank,spawnLoc.position,transform.rotation);
            Destroy(animationSpawned);
        }
    }
}