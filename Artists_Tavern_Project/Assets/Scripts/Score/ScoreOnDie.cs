using UnityEngine;

public class ScoreOnDie : ScoreGiver
{
    [SerializeField] HealthBehaviour _health = null;

    private void OnEnable()
    {
        _health.OnDie += _health_OnDie;
    }

    private void OnDisable()
    {
        _health.OnDie -= _health_OnDie;
    }

    private void _health_OnDie(HealthBehaviour arg0)
    {
        SendScore();
    }
}
