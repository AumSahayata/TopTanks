using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootDelayTime;

    private bool loadedToShoot = true;

    private void Start () {
        gameInput.OnShoot += GameInput_OnShoot;
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        if (inputVector != Vector2.zero) {
            transform.position += new Vector3(inputVector.x, inputVector.y, 0) * 5f * Time.deltaTime;

            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, inputVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotate, 8f * Time.deltaTime);
        }
    }

    IEnumerator ShootDelay() {
        if (!loadedToShoot) {
            print("reloading");
            yield return new WaitForSeconds(shootDelayTime);
            loadedToShoot = true;
            print("Ready to shoot");
        }
    }
    private void GameInput_OnShoot(object sender, System.EventArgs e) {
        Shoot();
    }

    private void Shoot() {
        if(bulletSpawnPoint == null) {
            return;
        }
        if (loadedToShoot) {
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            loadedToShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("EnemyBullet")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }


}