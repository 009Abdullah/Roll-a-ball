using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public float bulletLifetime = 2.0f;
    public delegate void PickupCollected();
    public static event PickupCollected OnPickupCollected;

    public delegate void EnemyDestroyed(GameObject enemy);
    public static event EnemyDestroyed OnEnemyDestroyed;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage();
            if (enemyHealth.IsDead())
            {
                
                OnEnemyDestroyed?.Invoke(other.gameObject);
                OnPickupCollected?.Invoke();
                ScoreController.AddScore(1);
            }
            Destroy(other, bulletLifetime);
        }
    }
}
