using UnityEngine;
using UnityEngine.Events;

public class ProjectileAgent : MonoBehaviour
{
    [SerializeField] TagCollectionSO _tagSO = null;
    [SerializeField] int _damage = 1;

    public event UnityAction OnHit = null;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out ProjectileDamageable _damageable) && _tagSO.HasTag(_other.gameObject))
        {
            _damageable.TakeDamage(_damage);
            OnHit?.Invoke();
            Destroy(gameObject);
        }
    }
}
