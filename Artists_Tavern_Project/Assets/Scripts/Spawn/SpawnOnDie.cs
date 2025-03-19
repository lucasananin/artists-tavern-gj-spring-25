using UnityEngine;

public class SpawnOnDie : AbstractSpawner
{
    [SerializeField] HealthBehaviour _health = null;

    private void OnEnable()
    {
        _health.OnDie += Spawn;
    }

    private void OnDestroy()
    {
        _health.OnDie -= Spawn;
    }

    private void Spawn(HealthBehaviour arg0)
    {
        Spawn();
    }
}
