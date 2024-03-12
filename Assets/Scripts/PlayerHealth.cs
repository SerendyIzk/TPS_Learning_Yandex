using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;

    public RectTransform ValueRectTransform;

    private float _maxHealth;

    public void DealDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) PlayerIsDead();
        DrawHealthBar();
    }

    public void AddHealth(float Amount)
    {
        Health += Amount;
        Health = Mathf.Clamp(Health, 0, _maxHealth);
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Health / _maxHealth, 1);
    }

    private void PlayerIsDead()
    {
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

    private void Start()
    {
        _maxHealth = Health;
        DrawHealthBar();
    }
}
