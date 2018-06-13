using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public int speedModifier = 100;

  private Rigidbody2D rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime * 100);
	}
}
