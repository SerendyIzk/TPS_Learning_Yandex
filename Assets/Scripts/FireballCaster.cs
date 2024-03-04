using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{

    public Fireball Fireball;

    public Transform FireballSourceTransform;

    private void FireballSpawnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Fireball, FireballSourceTransform.position, FireballSourceTransform.rotation);
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
