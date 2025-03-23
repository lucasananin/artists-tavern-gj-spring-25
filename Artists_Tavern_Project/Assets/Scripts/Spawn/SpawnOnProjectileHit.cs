using UnityEngine;

public class SpawnOnProjectileHit : AbstractSpawner
{
    [SerializeField] ProjectileAgent _projectile = null;
    [SerializeField] AudioSO _audioSO = null;

    private void OnEnable()
    {
        _projectile.OnHit += Spawn;
        _projectile.OnHit += _audioSO.Play;
    }

    private void OnDisable()
    {
        _projectile.OnHit += _audioSO.Play;
    }
}
