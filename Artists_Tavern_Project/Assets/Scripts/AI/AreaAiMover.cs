using DG.Tweening;
using UnityEngine;

public class AreaAiMover : AiMover
{
    [SerializeField] float _duration = 1f;
    [SerializeField] int _areaIndex = 0;
    [SerializeField] Vector2 _waitTimeRange = default;

    [Header("// Readonly")]
    [SerializeField] EnemySpawner _enemySpawner = null;
    [SerializeField] float _timer = 0f;
    [SerializeField] float _waitTime = 0f;

    private void Start()
    {
        _enemySpawner = FindFirstObjectByType<EnemySpawner>();
        _timer = _waitTime;
        ResetIdleTime();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _waitTime)
        {
            _timer = 0f;
            ResetIdleTime();
            Move();
        }
    }

    public void Move()
    {
        var _position = _enemySpawner.GetRandomPointInArea(_areaIndex);
        _rb.DOMove(_position, _duration);
    }

    public void ResetIdleTime()
    {
        _waitTime = Random.Range(_waitTimeRange.x, _waitTimeRange.y);
    }
}
