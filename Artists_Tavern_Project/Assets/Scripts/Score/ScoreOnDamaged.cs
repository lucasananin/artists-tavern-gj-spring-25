using UnityEngine;

public class ScoreOnDamaged : ScoreGiver
{
    [SerializeField] HealthBehaviour _health = null;

    private void OnEnable()
    {
        _health.OnTakeDamage += _health_OnTakeDamage;
    }

    private void OnDisable()
    {
        _health.OnTakeDamage += _health_OnTakeDamage;
    }

    private void _health_OnTakeDamage(HealthBehaviour arg0)
    {
        SendScore();
    }
}
