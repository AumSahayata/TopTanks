using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour {

    [SerializeField] private GameObject key;
    [SerializeField] private Transform[] spawnPointsArray;

    private int keySpawnCount;
    private KeyScript keyScript;

    private void Awake () {
        keySpawnCount = GameObject.FindObjectOfType<GameManager>().keyTarget;
    }
    private void Start() {
        spawnKey();
    }

    private void spawnKey() {

        if (keySpawnCount > 0) {
            Transform spawnLoc = spawnPointsArray[Random.Range(0,spawnPointsArray.Length)];

            GameObject spawnedKey =  Instantiate(key, spawnLoc.position, spawnLoc.rotation);

            keyScript = spawnedKey.GetComponent<KeyScript>();
            keyScript.OnPickupKey += KeyScript_OnPickupKey;
        }

        keySpawnCount--;

    }

    private void KeyScript_OnPickupKey(object sender, System.EventArgs e) {
        spawnKey();
    }
}