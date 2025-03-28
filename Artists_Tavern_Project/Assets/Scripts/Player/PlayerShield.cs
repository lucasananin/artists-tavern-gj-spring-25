using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] PlayerWeapon _playerWeapon = null;
    [SerializeField] Collider2D _collider = null;
    [SerializeField] SpriteRenderer _renderer = null;
    [SerializeField] ParticleSystem _ps = null;

    private bool _lastValue = false;

    private void Update()
    {
        EnableShield(!_playerWeapon.IsHoldingTrigger);
    }

    public void EnableShield(bool _value)
    {
        if (_value == _lastValue) return;

        _collider.enabled = _value;
        _renderer.enabled = _value;
        _lastValue = _value;

        if (_value)
        {
            _ps.Play();
        }
        else
        {
            _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    public bool IsEnabled()
    {
        return _collider.isActiveAndEnabled;
    }
}
