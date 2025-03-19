using UnityEngine;

public class EntityDamageAgent : MonoBehaviour
{
    [SerializeField] TagCollectionSO _tagSO = null;
    [SerializeField] bool _destroyOnCollision = true;
    [SerializeField] int _damage = 99;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out EntityDamageable _damageable) && _tagSO.HasTag(_other.gameObject))
        {
            _damageable.TakeDamage(_damage);

            if (_destroyOnCollision)
                Destroy(gameObject);
        }
    }
}
