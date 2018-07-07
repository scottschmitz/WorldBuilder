using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform followTarget;
    public float moveSpeed = 2.0f;

	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(followTarget.position.x, followTarget.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
	}
}
