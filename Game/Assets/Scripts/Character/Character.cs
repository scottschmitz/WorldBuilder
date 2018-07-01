using System;
using UnityEngine;

public class Character: MonoBehaviour {

    protected Rigidbody2D rigidBody;
    public Vector2 movementVector = Vector2.zero;

    // Skills
    public Skill alchemy;
    public Skill crafting;
    public Skill fishing;
    public Skill cooking;
    public Skill mining;
    public Skill blacksmithing;

    public Inventory inventory;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();

        // TODO: Perserve skills across sessions
        alchemy = new Skill();
        crafting = new Skill();
        fishing = new Skill();
        cooking = new Skill();
        mining = new Skill();
        blacksmithing = new Skill();
    }

    void gainExperience(Skill.Type type, int amount) {
        switch(type) {
            case Skill.Type.ALCHEMY:
                alchemy.gainExperience(amount);
                break;
            case Skill.Type.CRAFTING:
                crafting.gainExperience(amount);
                break;
            case Skill.Type.FISHING:
                fishing.gainExperience(amount);
                break;
            case Skill.Type.COOKING:
                cooking.gainExperience(amount);
                break;
            case Skill.Type.MINING:
                mining.gainExperience(amount);
                break;
            case Skill.Type.BLACKSMITHING:
                blacksmithing.gainExperience(amount);
                break;
            default:
                Debug.LogError("Gaining experience for unhandled type: " + type);
                break;
        }
    }
}
