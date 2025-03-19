using UnityEngine;

public class LinearAiMover : AiMover
{
    [SerializeField] Vector2 _direction = default;
    [SerializeField] float _speed = 3f;
    [SerializeField] bool _pingPongX = false;
    [SerializeField] bool _pingPongY = false;

    [Header("// Readonly")]
    [SerializeField] PingPongVfx _pingPongBehaviour = null;
    [SerializeField] Vector2 _initialPosition = default;

    private void Start()
    {
        _initialPosition = transform.position;

        var _velocity = _direction * _speed;
        _rb.linearVelocity = _velocity;
    }

    private void Update()
    {
        if (_pingPongBehaviour != null)
        {
            var _x = _pingPongX ? _pingPongBehaviour.GetXValue() /*+ _initialPosition.x */: _rb.position.x;
            var _y = _pingPongY ? _pingPongBehaviour.GetYValue() /*+ _initialPosition.y */: _rb.position.y;
            _rb.position = new Vector2(_x, _y);
            //_rb.linearVelocity = new Vector2(_x, _y);
        }
    }
}
