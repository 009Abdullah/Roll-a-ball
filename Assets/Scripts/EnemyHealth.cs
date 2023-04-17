using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private bool hasBeenHit=false;
    private Animator animator;

    public ParticleSystem enemyParticles;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 1.5f;
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        if (!hasBeenHit)
        {
            soundManager.instance.PlayDamageSound();
            Debug.Log("chal rha ha");
            animator.SetTrigger("HitTrigger");
        }
        
        currentHealth--;
        GameEvents.EnemyHealthUpdate("abdullah", 3);
        if (currentHealth <= 0)
        {
            soundManager.instance.PlayKillSound();
            animator.SetTrigger("DeathTrigger");
            enemyParticles.gameObject.SetActive(true);
            Destroy(gameObject, 2f);
            Debug.Log("Enemy Destroy");
            //Destroy(gameObject);
            //Debug.Log("Enemy Destroy");
        }
        else
        {
            enemyParticles.gameObject.SetActive(false);
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
