using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject destroyEffect;

    private Vector2 moveDir;
    private void Update() {
        transform.position += new Vector3(moveDir.x,moveDir.y) * bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.CompareTag("Enemy")) {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Setup(Vector3 dir) {
        moveDir = dir.normalized;
    }

}