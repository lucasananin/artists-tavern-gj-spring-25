using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D _prefab = null;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] float _shootForce = 10f;

    public event UnityAction<WeaponBehaviour> OnShoot = null;

    public virtual void Shoot()
    {
        var _projectile = Instantiate(_prefab, _muzzle.position, _muzzle.rotation);
        _projectile.linearVelocity = _muzzle.up.normalized * _shootForce;
        OnShoot?.Invoke(this);
    }
}
