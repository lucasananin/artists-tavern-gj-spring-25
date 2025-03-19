using UnityEngine;

public class PingPongVfx : MonoBehaviour
{
    [SerializeField] Transform _transform = null;
    [SerializeField] bool _update = false;
    [SerializeField] bool _useSin = true;
    [SerializeField, Range(0f, 9f)] float _speed = 1f;
    [SerializeField, Range(0f, 9f)] float _xMagnitude = 0f;
    [SerializeField, Range(0f, 9f)] float _yMagnitude = 1f;

    private Vector2 _initialPosition = default;
    private float _timer = 0f;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        _timer += Time.deltaTime * _speed;

        if (!_update) return;

        Vector3 _position = new Vector3(GetXValue(), GetYValue());
        _transform.localPosition = _position;
    }

    public float GetXValue()
    {
        return _useSin ? GetSin(_xMagnitude) : GetCos(_xMagnitude);
    }

    public float GetYValue()
    {
        return _useSin ? GetSin(_yMagnitude) : GetCos(_yMagnitude);
    }

    public float GetSin(float _magnitude)
    {
        return _initialPosition.x + Mathf.Sin(_timer) * _magnitude;
    }

    public float GetCos(float _magnitude)
    {
        return _initialPosition.y + Mathf.Cos(_timer) * _magnitude;
    }
}
