using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float Damage = 10f;

    public Fireball Fireball;

    public Transform FireballSourceTransform;

    private void FireballSpawnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var _fireball = Instantiate(Fireball, FireballSourceTransform.position, FireballSourceTransform.rotation);
            _fireball.Damage = Damage;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        FireballSpawnUpdate();
    }
}
