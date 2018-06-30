using System.Collections;
using UnityEngine;

public class PlayerController : Character {

    public int speedModifier = 100;

    void Update () {
		movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementVector != Vector2.zero) {
            float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Apply the movement direction AFTER rotating!
        rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime * 100);
	}
}
