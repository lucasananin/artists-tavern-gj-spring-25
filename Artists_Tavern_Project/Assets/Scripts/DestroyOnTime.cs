using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    [SerializeField] float _time = 10;

    private void Start()
    {
        Destroy(gameObject, _time);
    }
}
