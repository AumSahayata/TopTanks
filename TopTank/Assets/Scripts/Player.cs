using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reloadTime = 2;
    [SerializeField] private int bulletAmount = 3;

    private bool loadedToShoot = true;
    private int remainingBullet;

    private void Awake() {
        remainingBullet = bulletAmount;
        
    }

    private void Start () {
        gameInput.OnShoot += GameInput_OnShoot;
        gameInput.OnReload += GameInput_OnReload;
    }

    private void GameInput_OnReload(object sender, System.EventArgs e) {
        StartCoroutine(Reload());
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

    IEnumerator Reload() {
        loadedToShoot = false;
        remainingBullet = 0;

        yield return new WaitForSeconds(reloadTime);
        remainingBullet = bulletAmount;
        loadedToShoot = true;
    
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
            remainingBullet--;
            if(remainingBullet == 0) {
                StartCoroutine(Reload());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("EnemyBullet")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public int GetRemainingBullet() {
        return remainingBullet;
    }
}