using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    public float ExperiencePerDamage;

    private PlayerProgress PlayerEXP;

    public void DealDamage(float _damage)
    {
        Health -= _damage;
        if (Health <= 0) Destroy(gameObject);
        PlayerEXP.AddExperience(ExperiencePerDamage);

    }
    private void Start()
    {
        PlayerEXP = FindObjectOfType<PlayerProgress>();
    }
}
