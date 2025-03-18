using UnityEngine;

public class ProjectileAgent : MonoBehaviour
{
    [SerializeField] int _damage = 1;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out ProjectileDamageable _damageable))
        {
            _damageable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
