using UnityEngine;

public abstract class AbstractMover : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb = null;

    public virtual void SetVelocity(Vector2 _value)
    {
        _rb.linearVelocity = _value;
    }

    public virtual void InvertVelocity()
    {
        _rb.linearVelocity *= -1f;
    }

    public virtual void StopVelocity()
    {
        _rb.linearVelocity = Vector2.zero;
    }
}
