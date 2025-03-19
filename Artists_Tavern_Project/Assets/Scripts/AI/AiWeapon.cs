using UnityEngine;

public class AiWeapon : WeaponBehaviour
{
    [SerializeField] float _fireRate = 0.1f;
    [SerializeField] float _burstRate = 1f;
    [SerializeField] int _shotsPerBurst = 3;

    [Header("// Readonly")]
    [SerializeField] float _nextFire = 0f;
    [SerializeField] float _nextBurst = 0;
    [SerializeField] int _currentShootCount = 0;
    [SerializeField] bool _isBursting = false;

    private void Update()
    {
        PullTrigger();
    }

    private void FixedUpdate()
    {
        if (_isBursting)
        {
            _nextFire += _nextFire < _fireRate ? Time.fixedDeltaTime : 0;

            if (_nextFire >= _fireRate)
            {
                Shoot();

                _currentShootCount++;

                if (_currentShootCount >= _shotsPerBurst)
                {
                    _nextFire = _fireRate;
                    _isBursting = false;
                }
                else
                {
                    _nextFire = 0;
                }
            }
        }
        else
        {
            _nextBurst += _nextBurst < _burstRate ? Time.fixedDeltaTime : 0;
        }
    }

    public void PullTrigger()
    {
        //if (_isBursting) return;
        if (_nextBurst < _burstRate) return;

        _nextBurst -= _burstRate;
        _currentShootCount = 0;
        _isBursting = true;
    }
}
