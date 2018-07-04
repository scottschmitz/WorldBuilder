using System.Collections;
using UnityEngine;

public class PlayerController : Character {

    public float speedModifier = 10.0f;

    public Action action1;
    public Action action2;

    private void Start() {
        Debug.Log("Setting Actions");
        ActionBar.Instance.setAction1(action1);
        ActionBar.Instance.setAction2(action2);
    }

    void Update() {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementVector != Vector2.zero) {
            float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // TODO: Figure out why it is not set in Character.Start()
        if (rigidBody == null) {
            Debug.Log("no rigidbody");
            rigidBody = GetComponent<Rigidbody2D>();
        }

        // Apply the movement direction AFTER rotating!
        rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime * speedModifier);
	}
}
