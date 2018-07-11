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

	private void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = calcTimeBetweenMoveCounter();
        timeToMoveCounter = calcTimeToMoveCounter();
	}
	
	private void Update () {

        // TODO: Consider two CircleCollider2D Triggers.
        // One that informs the chicken they have gone too far and 
        // should head back to their starting position. Once within the 
        // inner collider then can start to choose random movements
        // in any direction again.
        // This would probably want to be in a more generic 
        // random movement type class.


        if (moving) {
            timeToMoveCounter -= Time.deltaTime;
            _rigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f) {
                moving = false;
                timeBetweenMoveCounter = calcTimeBetweenMoveCounter();
            }
        } else {
            timeBetweenMoveCounter -= Time.deltaTime;
            _rigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f) {
                moving = true;
                timeToMoveCounter = calcTimeToMoveCounter();

                moveDirection = new Vector3(
                    Random.Range(-1f, 1f) * moveSpeed,
                    Random.Range(-1f, 1f) * moveSpeed,
                    0f
                );
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player collided with Chicken.");

            collision.gameObject.SetActive(false);
            GameManager.Instance.SetGameState(GameState.Death);
        }
    }

    private float calcTimeBetweenMoveCounter() {
        return Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
    }

    private float calcTimeToMoveCounter() {
        return Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }
}
