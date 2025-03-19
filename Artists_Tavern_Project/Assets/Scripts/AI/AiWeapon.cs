using UnityEngine;

public class AiWeapon : WeaponBehaviour
{
    [SerializeField] Vector2 _burstRateRange = default;
    [SerializeField] int _shotsPerBurst = 3;
    [SerializeField] float _fireRate = 0.1f;
    [SerializeField] bool _canAim = false;
    [Space]
    [SerializeField] TagCollectionSO _tagCollection = null;
    [SerializeField] ContactFilter2D _contactFilter = default;

    [Header("// Readonly")]
    [SerializeField] float _burstRate = 0f;
    [SerializeField] float _nextFire = 0f;
    [SerializeField] float _nextBurst = 0;
    [SerializeField] int _currentShootCount = 0;
    [SerializeField] bool _isBursting = false;

    private Collider2D[] _results = new Collider2D[3];

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
                SearchAimTarget();
                Shoot();

                _burstRate = Random.Range(_burstRateRange.x, _burstRateRange.y);
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
        if (_nextBurst < _burstRate) return;

        _nextBurst -= _burstRate;
        _currentShootCount = 0;
        _isBursting = true;
    }

    public void SearchAimTarget()
    {
        if (!_canAim) return;

        var _hits = Physics2D.OverlapCircle(transform.position, 99f, _contactFilter, _results);

        for (int i = 0; i < _hits; i++)
        {
            if (_tagCollection.HasTag(_results[i].gameObject))
            {
                Aim(_results[i].transform);
                break;
            }
        }
    }
}
