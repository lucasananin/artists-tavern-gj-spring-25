using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSO", menuName = "Scriptable Objects/WaveSO")]
public class WaveSO : ScriptableObject
{
    [SerializeField, Range(0.1f, 9f)] float _spawnTime = 0.4f;
    [SerializeField] WaveModel _model = null;

    public float SpawnTime { get => _spawnTime; private set => _spawnTime = value; }
    public WaveModel Model { get => _model; set => _model = value; }

    private void OnValidate()
    {
        _model.ResetEditorValues();
    }
}

[System.Serializable]
public class WaveModel
{
    [SerializeField] EntityGroup[] _entities = null;
    [SerializeField, Range(1, 999)] int _maxActiveSpawns = 4;

    [Header("// Readonly")]
    [SerializeField] protected int _totalAmount = 0;

    readonly List<float> _runtimeQuantities = new();

    public int MaxActiveSpawns { get => _maxActiveSpawns; private set => _maxActiveSpawns = value; }

    public GameObject GetEntityPrefab(out int _spawnAreaIndex)
    {
        bool _canSpawn;
        int _randomIndex;

        do
        {
            _randomIndex = Random.Range(0, _entities.Length);
            _canSpawn = _runtimeQuantities[_randomIndex] > 0;

        } while (!_canSpawn);

        _spawnAreaIndex = _entities[_randomIndex].SpawnAreaIndex;
        _runtimeQuantities[_randomIndex]--;
        return _entities[_randomIndex].Prefab;
    }

    public void ResetRuntimeAmount()
    {
        _runtimeQuantities.Clear();
        int _count = _entities.Length;

        for (int i = 0; i < _count; i++)
        {
            _runtimeQuantities.Add(_entities[i].Amount);
        }
    }

    public void ResetEditorValues()
    {
        _totalAmount = GetTotalAmount();
    }

    public int GetTotalAmount()
    {
        if (_entities is null) return 0;

        int _count = _entities.Length;
        int _total = 0;

        for (int i = 0; i < _count; i++)
        {
            _total += _entities[i].Amount;
        }

        return _total;
    }
}

[System.Serializable]
public class EntityGroup
{
    [SerializeField] GameObject _prefab = null;
    [SerializeField, Range(0, 99)] int _amount = 1;
    [SerializeField] int _spawnAreaIndex = 0;

    public GameObject Prefab { get => _prefab; set => _prefab = value; }
    public int Amount { get => _amount; set => _amount = value; }
    public int SpawnAreaIndex { get => _spawnAreaIndex; set => _spawnAreaIndex = value; }
}
