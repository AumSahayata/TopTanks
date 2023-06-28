using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShooterTankScript : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject tankDestroyEffect;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private Transform target;
    private Vector2 moveDir;

    private void Start() {
        try {
            target = GameObject.FindWithTag("Player").transform;
            StartCoroutine(Shoot());
        } catch {
            print("player not found");
        }
    }

    private void Update() {
        if (target) {
            Vector3 dir = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDir = dir;
        }
    }

    private void FixedUpdate() {
        if (target) {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(tankDestroyEffect, transform.position, transform.rotation);
        } else if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot() {
        while (true)
        {
            yield return new WaitForSeconds(2);

            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            spawnedBullet.GetComponent<EnemyBulletScript>().Setup(moveDir);
        }
    }
}