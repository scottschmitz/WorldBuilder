using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    
    public float duration = 2.0f;

    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        Destroy(gameObject, duration);
	}
	
	// Update is called once per frame
    void Update () {
        body.MovePosition(transform.position + transform.right * Time.deltaTime * 100);
	}
}
