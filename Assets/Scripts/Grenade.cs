using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float ExplosionDelay = 3f;

    public GameObject ExplosionPrefab;

    private void Explosion()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
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
