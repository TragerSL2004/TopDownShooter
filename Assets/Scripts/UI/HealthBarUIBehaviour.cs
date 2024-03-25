using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIBehaviour : MonoBehaviour
{
    [SerializeField] private RawImage _healthBarFG;

    [SerializeField] private HealthBehaviour _healthBehaviour;

    [SerializeField] private Gradient _healthBarGradient;

    private void Start()
    {
        Debug.Assert(_healthBarFG);
        Debug.Assert(_healthBehaviour);

    }
    private void Update()
    {
        if (_healthBarFG == null || _healthBehaviour == null)
            return;

        float health = _healthBehaviour.Health;

        //Min of 1 to ensure no dividing by zero or negative numbers
        float maxHealth = Mathf.Max(1, _healthBehaviour.MaxHealth);

        //Get health as value between 0 and 1.
        float healthPercentage = Mathf.Clamp01(health / maxHealth);

        //Set health bar scale.
        Vector3 newScale = _healthBarFG.rectTransform.localScale;
        newScale.x = healthPercentage;
        _healthBarFG.rectTransform.localScale = newScale;

        //Set health bar color
        _healthBarFG.color = _healthBarGradient.Evaluate(healthPercentage);
    }
}
