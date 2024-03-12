using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;

    public void DealDamage(float _damage)
    {
        Health -= _damage;
        if (Health <= 0) Destroy(gameObject);
    }
}
