using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamag : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeHit(damageAmount);
            }
        }
    }
}
