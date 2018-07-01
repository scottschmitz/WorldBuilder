using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public GameObject inventoryPanel;

	void Start () {
        hideAll();
	}
	
    public void ToggleInventory() {
        bool isInvCurrState = inventoryPanel.activeSelf;
        hideAll();
        inventoryPanel.SetActive(!isInvCurrState);
    }

    private void hideAll() {
        inventoryPanel.SetActive(false);
    }
}
