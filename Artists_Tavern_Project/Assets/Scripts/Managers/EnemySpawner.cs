using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveSO[] _waves = null;
    [SerializeField] BoxCollider2D[] _spawnAreas = null;
    [SerializeField] float _waveInitialDelay = 2f;
    [SerializeField] bool _spawnOnStart = true;

    public UnityEvent OnAllWavesFinished = null;

    [Header("// Readonly")]
    [SerializeField] int _currentWaveIndex = 0;
    [SerializeField] int _activeSpawns = 0;

    private void Start()
    {
        if (_spawnOnStart)
        {
            StartSpawning();
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnWave_Routine());
    }

    private IEnumerator SpawnWave_Routine()
    {
        while (_currentWaveIndex < _waves.Length)
        {
            yield return StartCoroutine(SpawnEnemies_Routine());

            _currentWaveIndex++;
        }

        if (_currentWaveIndex >= _waves.Length)
        {
            OnAllWavesFinished?.Invoke();
            Debug.Log($"All waves finished!");
        }
    }

    private IEnumerator SpawnEnemies_Routine()
    {
        yield return new WaitForSeconds(_waveInitialDelay);

        var _so = _waves[_currentWaveIndex];
        var _model = _so.Model;
        _model.ResetRuntimeAmount();
        var _spawnCount = 0;
        var _totalAmount = _model.GetTotalAmount();

        while (_spawnCount < _totalAmount)
        {
            while (_activeSpawns >= _model.MaxActiveSpawns)
            {
                yield return null;
            }

            var _entityPrefab = _model.GetEntityPrefab(out int _spawnAreaIndex);
            var _position = RandomPointInBounds(_spawnAreas[_spawnAreaIndex].bounds);
            var _instance = Instantiate(_entityPrefab, _position, Quaternion.identity);
            _instance.GetComponent<AiHealth>().SetOnDestroy(DecreaseActiveSpawns);

            _spawnCount++;
            _activeSpawns++;

            yield return new WaitForSeconds(_so.SpawnTime);
        }

        while (_activeSpawns > 0)
        {
            yield return null;
        }
    }

    private void DecreaseActiveSpawns()
    {
        _activeSpawns--;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public Vector3 GetRandomPointInArea(int _areaIndex)
    {
        var _area = _spawnAreas[_areaIndex];
        return RandomPointInBounds(_area.bounds);
    }
}
