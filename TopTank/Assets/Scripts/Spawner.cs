using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject spawnTank;
    [Range(2f,5f)] [SerializeField] private float minSpawnTime;
    [Range(3f,7f)] [SerializeField] private float maxSpawnTime;

    private void Start() {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            GameObject enemy = Instantiate(spawnTank,new Vector2(transform.position.x+Random.Range(0,2), transform.position.y + Random.Range(0,2)),transform.rotation);
            enemy.GetComponent<ChasingTankScript>().SetMoveSpeed(Random.Range(3, 6));
        }
    }
}