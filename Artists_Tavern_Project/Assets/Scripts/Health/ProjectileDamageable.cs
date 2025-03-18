using UnityEngine;

public class ProjectileDamageable : MonoBehaviour
{
    [SerializeField] HealthBehaviour _health = null;

    public void TakeDamage(int _value)
    {
        _health.TakeDamage(_value);
    }
}
