using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] PlayerWeapon _playerWeapon = null;
    [SerializeField] int _costPerShot = 1;
    [Space]
    [SerializeField] int _maxValue = 100;
    [SerializeField] int _currentValue = 0;

    public event UnityAction<PlayerEnergy> OnValueChanged = null;

    private void Start()
    {
        RestoreValue();
    }

    private void OnEnable()
    {
        _playerWeapon.OnShoot += OnShoot;
    }

    private void OnDisable()
    {
        _playerWeapon.OnShoot -= OnShoot;
    }

    private void OnShoot(WeaponBehaviour arg0)
    {
        DecreaseValue(_costPerShot);
    }

    public void DecreaseValue(int _value)
    {
        _currentValue -= _value;

        if (_currentValue < 0) 
            _currentValue = 0;

        OnValueChanged?.Invoke(this);
    }

    public void IncreaseValue(int _value)
    {
        _currentValue += _value;

        if (_currentValue > _maxValue)
            _currentValue = _maxValue;

        OnValueChanged?.Invoke(this);
    }

    public void RestoreValue()
    {
        IncreaseValue(_maxValue);
    }

    public float GetNormalizedValue()
    {
        return _currentValue / (_maxValue * 1f);
    }

    public bool HasEnoughValue()
    {
        return _currentValue >= _costPerShot;
    }
}
