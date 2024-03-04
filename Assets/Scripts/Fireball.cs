using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float Lifetime;
    public float Damage;

    private void FlyingFixedUpdate()
    {
        transform.position = transform.position + transform.forward * Speed * Time.deltaTime;
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<EnemyHealth>() != null) col.gameObject.GetComponent<EnemyHealth>().Health -= Damage;
        if (!col.CompareTag("Player")) DestroyFireball();
    }

    private void Start()
    {
        Invoke("DestroyFireball", Lifetime);
    }

    private void FixedUpdate()
    {
        FlyingFixedUpdate();
    }
}
