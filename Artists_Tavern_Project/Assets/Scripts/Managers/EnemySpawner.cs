using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] BoxCollider2D[] _spawnAreas = null;
    [SerializeField] GameObject _enemyPrefab = null;
    [SerializeField] float _waveInitialDelay = 2f;
    [SerializeField] float _spawnDelay = 1f;
    [SerializeField] bool _spawnOnStart = true;

    private void Start()
    {
        if (_spawnOnStart)
            StartCoroutine(Spawn_Routine());
    }

    private IEnumerator Spawn_Routine()
    {
        yield return new WaitForSeconds(_waveInitialDelay);

        while (true)
        {
            var _position = RandomPointInBounds(_spawnAreas[0].bounds);
            var _instance = Instantiate(_enemyPrefab, _position, Quaternion.identity);

            yield return new WaitForSeconds(_spawnDelay);
        }
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
