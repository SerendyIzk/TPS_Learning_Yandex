using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage;
    public float MaxSize = 10;
    public float ExplosionSpeed;

    private void OnTriggerEnter(Collider col)
    {
        var _playerHealth = col.GetComponent<PlayerHealth>();
        if (_playerHealth != null) _playerHealth.DealDamage(Damage);

        var _enemyHealth = col.GetComponent<EnemyHealth>();
        if (_enemyHealth != null) _enemyHealth.DealDamage(Damage);
    }

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * ExplosionSpeed;
        if (transform.localScale.x >= MaxSize) Destroy(gameObject);
    }
}
