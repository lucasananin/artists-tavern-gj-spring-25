using UnityEngine;

public class SpawnOnDie : AbstractSpawner
{
    [SerializeField] HealthBehaviour _health = null;
    [SerializeField] AudioSO _audioSO = null;

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
        if (_audioSO != null)
            _audioSO.Play();
    }
}
