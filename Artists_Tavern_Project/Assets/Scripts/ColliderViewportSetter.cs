using UnityEngine;

public class ColliderViewportSetter : MonoBehaviour
{
    [SerializeField] BoxCollider2D _collider = null;
    [SerializeField] Vector2 _viewport = default;
    [SerializeField] Vector2 _offset = default;
    [SerializeField] float _widthOffset = 1f;
    [SerializeField] bool _setPosition = true;
    [SerializeField] bool _setSize = false;

    private void OnValidate()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        if (_setPosition)
            SetPosition();

        if (_setSize)
            SetSize();
    }

    public void SetPosition()
    {
        var _worldPosition = Camera.main.ViewportToWorldPoint(_viewport);
        var _position = (Vector2)_worldPosition + _offset;
        transform.position = _position;
        //_collider.offset = _position;
        //_collider.offset = new Vector2(_xOffset, _collider.offset.y);
    }

    public void SetSize()
    {
        float _screenWidthWorld = Camera.main.orthographicSize * 2f * Screen.width / Screen.height;
        _collider.size = new Vector2(_screenWidthWorld - _widthOffset, _collider.size.y);
    }
}
