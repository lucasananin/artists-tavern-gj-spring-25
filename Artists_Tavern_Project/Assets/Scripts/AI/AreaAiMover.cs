using DG.Tweening;
using UnityEngine;

public class AreaAiMover : AiMover
{
    [SerializeField] float _duration = 1f;
    [SerializeField] int _areaIndex = 0;
    [SerializeField] Vector2 _waitTimeRange = default;
    [SerializeField] bool _useMoveCount = false;
    [SerializeField] int _moveCount = 0;
    [SerializeField] int _maxMoveCount = 1;

    [Header("// Readonly")]
    [SerializeField] EnemySpawner _enemySpawner = null;
    [SerializeField] float _timer = 0f;
    [SerializeField] float _waitTime = 0f;

    private void Start()
    {
        _enemySpawner = FindFirstObjectByType<EnemySpawner>();
        ResetWaitTime();
        _timer = _waitTime;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _waitTime && HasMovePoints())
        {
            _timer = 0f;
            _moveCount++;
            ResetWaitTime();
            Move();
        }
    }

    public void Move()
    {
        var _position = _enemySpawner.GetRandomPointInArea(_areaIndex);
        _rb.DOMove(_position, _duration);
    }

    public void ResetWaitTime()
    {
        _waitTime = Random.Range(_waitTimeRange.x, _waitTimeRange.y);
    }

    public bool HasMovePoints()
    {
        return !_useMoveCount || _useMoveCount && _moveCount < _maxMoveCount;
    }
}
