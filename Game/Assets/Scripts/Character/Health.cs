using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int totalHealth = 100;
    public int currentHealth = 100;

    bool takeDamage(int amount) {
        currentHealth -= amount;
        return currentHealth <= 0;
    }

    void healDamage(int amount) {
        currentHealth = Mathf.Min(totalHealth, currentHealth + amount);
    }
}
