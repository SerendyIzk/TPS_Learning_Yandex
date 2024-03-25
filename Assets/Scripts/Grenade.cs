using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float ExplosionDelay = 3f;
    public float Damage;

    public GameObject ExplosionPrefab;

    private void Explosion()
    {
        var _explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        _explosion.GetComponent<Explosion>().Damage = Damage;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        Invoke("Explosion", ExplosionDelay);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
