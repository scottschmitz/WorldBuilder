using UnityEngine;
using System.Collections;

class BowAttack : Action {
    
    public float duration = 0.75f;
    public float cooldownDuration = 4.0f;
    public Transform arrowTransform;
    public Rigidbody2D arrowTemplate;

    private float endTime = 0f;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        bool performingAction = Time.time < endTime;
        //sprite.enabled = performingAction;
    }

    //
    // Action Class Overrides
    //
    public override float getCooldownDuration() {
        return cooldownDuration;
    }

    public override KeyCode getKeyCode() {
        return KeyCode.F;
    }

    public override void perform() {
        endTime = Time.time + duration;
        Instantiate(arrowTemplate, arrowTransform.position, arrowTransform.rotation);
    }
}
