using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth--;
        GameEvents.EnemyHealthUpdate("abdullah", 3);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Destroy");
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public float GetHealthPercentage()
    {
        return (float)currentHealth / (float)maxHealth;
    }

}
