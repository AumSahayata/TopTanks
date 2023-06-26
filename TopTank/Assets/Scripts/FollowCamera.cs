using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform playerTransform;

    private void LateUpdate() {
        transform.position = playerTransform.position;
    }

}