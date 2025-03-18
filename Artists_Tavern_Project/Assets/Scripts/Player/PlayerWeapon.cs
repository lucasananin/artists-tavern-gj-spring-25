using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : WeaponBehaviour
{
    [Space]
    [SerializeField] PlayerEnergy _energy = null;
    [SerializeField] float _fireRate = 0.1f;

    [Header("// Readonly")]
    [SerializeField] float _nextFire = 0f;
    [SerializeField] bool _isHoldingTrigger = false;

    public bool IsHoldingTrigger { get => _isHoldingTrigger; private set => _isHoldingTrigger = value; }

    private void Update()
    {
        _isHoldingTrigger = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        _nextFire += Time.fixedDeltaTime;

        if (_nextFire > _fireRate && _isHoldingTrigger && _energy.HasEnoughValue())
        {
            _nextFire = 0;
            Shoot();
        }
    }
}
