using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        if(playerTransform == null) {
            return;
        }

        transform.position = playerTransform.position;
    }

}