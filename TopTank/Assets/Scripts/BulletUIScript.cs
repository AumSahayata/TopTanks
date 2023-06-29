using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletUIScript : MonoBehaviour {

    [SerializeField] private Text bulletCount;
    [SerializeField] private Image bulletImage;

    private GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    private void Start() {
        SetBulletCount();
    }

    private void LateUpdate() {
        SetBulletCount();
    }
    private void SetBulletCount() {
        if (player == null)
            return;

        bulletCount.text = player.GetComponent<Player>().GetRemainingBullet().ToString();
        if (bulletCount.text == "0")
            bulletImage.fillAmount = 0.1f;
        else
            bulletImage.fillAmount = 1f;

    }

}