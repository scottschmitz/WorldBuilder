using UnityEngine;
using System.Collections;

class SwordAttack: MonoBehaviour, Action {

    public float duration = 0.25f;

    private float endTime = 0f;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        bool performingAction = Time.time < endTime;

        if (!performingAction && Input.GetKey(KeyCode.Space)) {
            performingAction = true;
            performAction();
        }

        sprite.enabled = performingAction;
    }

    public void performAction() {
        endTime = Time.time + duration;
    }
}
