using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    private static HUD _instance;
    private static GameManager _gm;

    private GameObject hudPanel;

    private Inventory inventory;

    public static HUD Instance {
        get {
            // if we do not have an instance already, lets look to see
            // if one has already been created for us
            if (_instance == null) {
                _instance = Object.FindObjectOfType<HUD>();
            }

            // If we still dont have an instance, one must not be created
            // so lets create our own and prevent it from being deleted
            // when the level changes
            if (_instance == null) {
                // Lets go ahead and grab a reference to the GameManager to shorted all the text each time
                _gm = GameManager.Instance;
                _gm.OnStateChange += onGameStateChange;
                _instance = _gm.gameObject.AddComponent<HUD>();

                GameObject guiCanvas = GameObject.Find("_GUI");

                // Now that we have created the Base object we need to add our HUD components to it
                _instance.hudPanel = (GameObject)Instantiate(Resources.Load("GUI/HUD"), new Vector3(), Quaternion.identity);
                _instance.hudPanel.transform.SetParent(guiCanvas.transform);
                _instance.hudPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                _instance.inventory = Object.FindObjectOfType<Inventory>();
            }

            return _instance;
        }
    }

    private static void onGameStateChange() {
        Debug.Log("HUD:onGameStateChange - " + _gm.gameState);
    }

    public Inventory GetInventory() {
        return inventory;
    }
}
