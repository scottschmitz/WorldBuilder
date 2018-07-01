using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D other) {
        Character character = other.gameObject.GetComponent<Character>();

        if (character.inventory.addItem(this)) {
            Destroy(this.gameObject);
        } else {
            Debug.Log("Inventory full.");
        }
    }

}
