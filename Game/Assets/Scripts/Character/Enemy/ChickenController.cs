using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour {

    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;

    private Rigidbody2D _rigidbody;
    private bool moving;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving) {
            timeToMoveCounter -= Time.deltaTime;
            _rigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f) {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        } else {
            timeBetweenMoveCounter -= Time.deltaTime;
            _rigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f) {
                moving = true;
                timeToMoveCounter = timeToMove;

                moveDirection = new Vector3(
                    Random.Range(-1f, 1f) * moveSpeed,
                    Random.Range(-1f, 1f) * moveSpeed,
                    0f
                );
            }
        }
	}
}
