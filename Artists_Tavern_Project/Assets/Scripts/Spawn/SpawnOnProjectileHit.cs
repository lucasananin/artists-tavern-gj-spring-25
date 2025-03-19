using UnityEngine;

public class SpawnOnProjectileHit : AbstractSpawner
{
    [SerializeField] ProjectileAgent _projectile = null;

    private void OnEnable()
    {
        _projectile.OnHit += Spawn;
    }

    private void OnDisable()
    {
        _projectile.OnHit -= Spawn;
    }
}
