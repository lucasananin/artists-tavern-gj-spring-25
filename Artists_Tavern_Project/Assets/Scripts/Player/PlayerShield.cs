using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] PlayerWeapon _playerWeapon = null;
    [SerializeField] Collider2D _collider = null;
    [SerializeField] SpriteRenderer _renderer = null;

    private void Update()
    {
        EnableShield(!_playerWeapon.IsHoldingTrigger);
    }

    public void EnableShield(bool _value)
    {
        _collider.enabled = _value;
        _renderer.enabled = _value;
    }

    public bool IsEnabled()
    {
        return _collider.isActiveAndEnabled;
    }
}
