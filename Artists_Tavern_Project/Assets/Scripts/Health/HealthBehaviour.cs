using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] protected int _maxValue = 100;
    [SerializeField] protected int _currentValue = 0;

    public event UnityAction<HealthBehaviour> OnTakeDamage = null;
    public event UnityAction<HealthBehaviour> OnDie = null;

    public UnityEvent OnDie_UEvent = null;

    protected virtual void Awake()
    {
        RestoreMaxHealth();
    }

    public virtual void TakeDamage(int _value)
    {
        _currentValue -= _value;

        if (_currentValue <= 0)
        {
            _currentValue = 0;
            Die();
        }
        else
        {
            OnTakeDamage?.Invoke(this);
        }
    }

    public virtual void Die()
    {
        OnDie?.Invoke(this);
        OnDie_UEvent?.Invoke();
    }

    public void RestoreHealth(int _value)
    {
        _currentValue += _value;

        if (_currentValue > _maxValue)
            _currentValue = _maxValue;
    }

    public void RestoreMaxHealth()
    {
        RestoreHealth(_maxValue);
    }
}
