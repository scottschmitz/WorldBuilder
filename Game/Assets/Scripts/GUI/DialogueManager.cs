using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;

    public bool dialogueActive;
	
	void Update () {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
            dialogueBox.SetActive(false);
            dialogueActive = false;
        }
	}

    public void showBox(string dialogue) {
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue
    }
}
