using UnityEngine;

public class ShieldDamageable : MonoBehaviour
{
    [SerializeField] HealthBehaviour _health = null;
    [SerializeField] int _energyRestore = 10;

    public int EnergyRestore { get => _energyRestore; private set => _energyRestore = value; }

    public void TakeDamage(int _value)
    {
        _health.TakeDamage(_value);
    }
}
