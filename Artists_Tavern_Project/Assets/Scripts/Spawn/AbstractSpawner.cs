using UnityEngine;

public abstract class AbstractSpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab = null;

    public virtual void Spawn()
    {
        Instantiate(_prefab, transform.position, transform.rotation);
    }
}
