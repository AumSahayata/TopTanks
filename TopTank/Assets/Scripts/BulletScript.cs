using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject destroyEffect;
    private void Update() {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.CompareTag("Player")) {
            Instantiate(destroyEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}