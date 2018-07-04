using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {

    public Action action;
    public Image loadingImage;

    private float start;
    private float end;

    void Update() {
        if (action == null) {
            return;
        }

        if (Time.time > end) {
            if (Input.GetKey(action.getKeyCode())) {
                action.perform();
                start = Time.time;
                end = start + action.getCooldownDuration();
            }    
        }

        if (Time.time < end) {
            loadingImage.fillAmount = (end - Time.time) / action.getCooldownDuration();
        } else {
            loadingImage.fillAmount = 1.0f;
        }
    }
}
