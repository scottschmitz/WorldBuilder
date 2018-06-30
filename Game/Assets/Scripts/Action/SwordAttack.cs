using UnityEngine;
using System.Collections;
 
public class SwordAttack: Action {

    public float duration = 0.25f;
    public float cooldownDuration = 2.0f;

    private float endTime = 0f;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        bool performingAction = Time.time < endTime;
        sprite.enabled = performingAction;
    }

    //
    // Action Class Overrides
    //
    public override float getCooldownDuration() {
        return cooldownDuration;
    }

    public override KeyCode getKeyCode() {
        return KeyCode.Space;
    }

    public override void perform() {
        endTime = Time.time + duration;
    }
}
