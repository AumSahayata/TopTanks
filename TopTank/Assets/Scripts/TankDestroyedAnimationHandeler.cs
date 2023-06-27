using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroyedAnimationHandeler : MonoBehaviour {

    private float ftimer = 3f;

    private void Update() {
        ftimer -= Time.deltaTime;
        if(ftimer <= 0) {
            Destroy(gameObject);
        }
    }

}