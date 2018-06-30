using System;
using UnityEngine;

public class Character: MonoBehaviour {

    protected Rigidbody2D rigidBody;
    protected Vector2 movementVector = Vector2.zero;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
    }
}
