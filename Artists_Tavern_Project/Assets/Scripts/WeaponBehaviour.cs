using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D _prefab = null;
    [SerializeField] Transform _weaponRoot = null;
    [SerializeField] Transform[] _muzzles = null;
    [SerializeField] float _shootForce = 10f;

    public event UnityAction<WeaponBehaviour> OnShoot = null;

    public virtual void Shoot()
    {
        int _count = _muzzles.Length;

        for (int i = 0; i < _count; i++)
        {
            var _muzzle = _muzzles[i];
            var _projectile = Instantiate(_prefab, _muzzle.position, _muzzle.rotation);
            _projectile.linearVelocity = _muzzle.up.normalized * _shootForce;
            OnShoot?.Invoke(this);
        }

    }

    public virtual void Aim(Transform _target)
    {
        var _direction = _target.position - transform.position;
        _weaponRoot.up = _direction.normalized;
    }
}
