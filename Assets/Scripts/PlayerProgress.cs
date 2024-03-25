using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> Levels;

    public RectTransform ExperienceValueRectTransform;
    public TextMeshProUGUI LevelValueTMP;

    private int _levelValue = 1;

    private float _experienceCurrentValue = 0f;
    private float _experienceTargetValue = 100f;

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;

        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;
        _experienceTargetValue = Levels[_levelValue - 1].ExperienceForTheNextLevel;
        GetComponent<FireballCaster>().Damage = Levels[_levelValue - 1].FireballDamage;

        var _grenadeCaster = GetComponent<GrenadeCaster>();
        _grenadeCaster.Damage = Levels[_levelValue - 1].GrenadeDamage;

        if (Levels[_levelValue - 1].GrenadeDamage < 0) _grenadeCaster.enabled = false;
        else _grenadeCaster.enabled = true;
    }

    private void DrawUI()
    {
        ExperienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        LevelValueTMP.text = _levelValue.ToString();
    }

    private void Start()
    {
        DrawUI();
        SetLevel(_levelValue);
    }
}
