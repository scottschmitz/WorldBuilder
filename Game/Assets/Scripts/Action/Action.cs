using System.Collections;
using UnityEngine;

public abstract class Action: MonoBehaviour {
    public abstract float getCooldownDuration();
    public abstract KeyCode getKeyCode();
    public abstract void perform();
}
