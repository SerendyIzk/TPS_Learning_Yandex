using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float ThrowForce;
    public float Damage;

    public Rigidbody Grenade;

    public Transform GrenadeSource;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var _grenade = Instantiate(Grenade, GrenadeSource.position, GrenadeSource.rotation);
            _grenade.GetComponent<Rigidbody>().AddForce(GrenadeSource.forward * ThrowForce);
            _grenade.GetComponent<Grenade>().Damage = Damage;
        }
    }
}
