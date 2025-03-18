using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D _prefab = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] Vector2 _shootDirection = default;
    [SerializeField] float _shootForce = 10f;

    public virtual void Shoot()
    {
        var _projectile = Instantiate(_prefab, _muzzle.position, _muzzle.rotation);
        _projectile.linearVelocity = _shootDirection.normalized * _shootForce;
    }
}
