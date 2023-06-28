using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;


    private void Start () {
        gameInput.OnShoot += GameInput_OnShoot;
    }


    private void GameInput_OnShoot(object sender, System.EventArgs e) {
        Shoot();
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

    private void Shoot() {
        if(bulletSpawnPoint == null) {
            return;
        }

        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("EnemyBullet")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }


}