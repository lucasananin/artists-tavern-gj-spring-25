using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AiHealth : HealthBehaviour
{
    public event UnityAction OnDestroy_Action = null;

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public void SetOnDestroy(UnityAction _value)
    {
        OnDestroy_Action += _value;
    }

    private void OnDestroy()
    {
        OnDestroy_Action?.Invoke();
        OnDestroy_Action = null;
    }
}
