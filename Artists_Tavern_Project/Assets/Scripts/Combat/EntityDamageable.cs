using UnityEngine;

public class EntityDamageable : MonoBehaviour
{
    [SerializeField] PlayerHealth _health = null;

    public void TakeDamage(int _value)
    {
        _health.PierceShield(_value);
    }
}
