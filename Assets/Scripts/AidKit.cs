using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    public float HealAmount = 30f;

    private void OnTriggerEnter(Collider col)
    {
        var _playerHealth = col.GetComponent<PlayerHealth>();
        if (_playerHealth != null)
        {
            _playerHealth.AddHealth(HealAmount);
            Destroy(gameObject);
        }
    }
}
