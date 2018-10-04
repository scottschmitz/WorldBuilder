using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;

    private DialogueManager dialogueManager;

	void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            if (Input.GetKeyDown(KeyCode.Space)) {
                dialogueManager.showBox(dialogue);
            }
        }    
    }
}
