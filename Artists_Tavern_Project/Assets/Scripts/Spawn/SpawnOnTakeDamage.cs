using UnityEngine;

public class SpawnOnTakeDamage : AbstractSpawner
{
    [SerializeField] HealthBehaviour _health = null;

    private void OnEnable()
    {
        _health.OnTakeDamage += Spawn;
    }

    private void OnDestroy()
    {
        _health.OnTakeDamage -= Spawn;
    }

    private void Spawn(HealthBehaviour arg0)
    {
        Spawn();
    }
}
