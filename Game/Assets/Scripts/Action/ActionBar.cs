using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour {

    public Cooldown cooldown1;
    public Cooldown cooldown2;

    private static ActionBar _instance;

    public static ActionBar Instance {
        get {
            // if we do not have an instance already, lets look to see
            // if one has already been created for us
            if (_instance == null) {
                _instance = Object.FindObjectOfType<ActionBar>();
            }

            if (_instance == null) {
                Debug.LogError("ActionBar not setup in HUD");
            }

            return _instance;
        }
    }

    public void setAction1(Action action) {
        Debug.Log("setting action 1: " + action);
        cooldown1.action = action;
    }

    public void setAction2(Action action) {
        Debug.Log("setting action 2: " + action);
        cooldown2.action = action;
    }
}
