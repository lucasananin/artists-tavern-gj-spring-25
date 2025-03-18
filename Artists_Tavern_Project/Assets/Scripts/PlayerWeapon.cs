using UnityEngine;

public class PlayerWeapon : WeaponBehaviour
{
    [SerializeField] float _fireRate = 0.1f;

    [Header("// Readonly")]
    [SerializeField] float _nextFire = 0f;
    [SerializeField] bool _isHoldingTrigger = false;

    private void Update()
    {
        _isHoldingTrigger = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        _nextFire += Time.fixedDeltaTime;

        if (_nextFire > _fireRate && _isHoldingTrigger)
        {
            _nextFire = 0;
            Shoot();
        }
    }
}
