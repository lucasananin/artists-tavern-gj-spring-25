using UnityEngine;

public class PlayerHealth : HealthBehaviour
{
    [SerializeField] PlayerShield _shield = null;

    public override void TakeDamage(int _value)
    {
        if (_shield.IsEnabled()) return;
        base.TakeDamage(_value);
    }

    public void PierceShield(int _value)
    {
        base.TakeDamage(_value);
    }

    public override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }
}
