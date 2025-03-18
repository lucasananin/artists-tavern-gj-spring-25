using UnityEngine;

public class LinearAiMover : AiMover
{
    [SerializeField] Vector2 _direction = default;
    [SerializeField] float _speed = 3f;

    private void Start()
    {
        var _velocity = _direction * _speed;
        _rb.linearVelocity = _velocity;
    }
}
