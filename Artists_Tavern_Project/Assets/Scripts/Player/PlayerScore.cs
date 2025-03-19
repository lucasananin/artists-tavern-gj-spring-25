using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int _score = 0;

    public event UnityAction OnValueChanged = null;  

    public int Score { get => _score; private set => _score = value; }

    private void Start()
    {
        Increase(0);
    }

    public void Increase(int _value)
    {
        _score += _value;
        OnValueChanged?.Invoke();
    }
}
