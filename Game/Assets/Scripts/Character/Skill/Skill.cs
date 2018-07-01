using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {

    public enum Type {
        ALCHEMY,
        CRAFTING,
        FISHING,
        COOKING,
        MINING,
        BLACKSMITHING
    }

    public Type type;
    public int experience { get; private set; }

    public int getLevel() {
        if (experience < 1) {
            return 1;
        } else if (experience < 2) {
            return 2;
        } else if (experience < 3) {
            return 3;
        } else if (experience < 4) {
            return 4;
        } else if (experience < 5) {
            return 5;
        } else if (experience < 6) {
            return 6;
        } else if (experience < 7) {
            return 7;
        } else if (experience < 8) {
            return 8;
        } else if (experience < 9) {
            return 9;
        } else {
            return 10;
        }
    }

    public void gainExperience(int amount) {
        experience += amount;
    }
}
