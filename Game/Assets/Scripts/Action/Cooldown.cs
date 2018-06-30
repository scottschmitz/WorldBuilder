using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour {

    public float cooldownTime = 2;
    private float nextFireTime = 0;

    void Update() {
        if (Time.time > nextFireTime) {
            if (Input.GetKey(KeyCode.Space)) {
                print("ability used, cooldown started");
                nextFireTime = Time.time + cooldownTime;
            }    
        }
    }
}
