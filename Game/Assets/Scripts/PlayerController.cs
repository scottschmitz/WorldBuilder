using System.Collections;
using UnityEngine;

public class PlayerController : Character {

    public int speedModifier = 100;
    public GameObject attackArea;

    void Update () {
		movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime * 100);
	}
}
