using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] float _speed = 5f;

    private void Update()
    {
        var _xInput = Input.GetAxisRaw("Horizontal");
        var _yInput = Input.GetAxisRaw("Vertical");
        var _direction = new Vector2(_xInput, _yInput).normalized;
        var _velocity = _direction * _speed;
        _rb.linearVelocity = _velocity;
    }
}
