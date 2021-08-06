using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // config params 
    [SerializeField] float health = 100f;
    [SerializeField] GameObject explosionVFX;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        var explosionVFXObj = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosionVFXObj, 2f);
    }
}
