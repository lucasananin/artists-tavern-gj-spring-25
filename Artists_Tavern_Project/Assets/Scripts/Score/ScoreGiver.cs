using UnityEngine;
using UnityEngine.Events;

public abstract class ScoreGiver : MonoBehaviour
{
    [SerializeField] int _value = 10;

    public static event UnityAction<int> OnScored = null;

    public virtual void SendScore()
    {
        OnScored?.Invoke(_value);
    }
}
