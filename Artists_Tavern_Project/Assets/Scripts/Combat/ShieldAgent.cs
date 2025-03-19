using UnityEngine;

public class ShieldAgent : MonoBehaviour
{
    [SerializeField] PlayerEnergy _energy = null;
    [SerializeField] int _damage = 1;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out ShieldDamageable _damageable))
        {
            _damageable.TakeDamage(_damage);
            _energy.IncreaseValue(_damageable.EnergyRestore);
            //Debug.Log($"b");
        }
    }
}
