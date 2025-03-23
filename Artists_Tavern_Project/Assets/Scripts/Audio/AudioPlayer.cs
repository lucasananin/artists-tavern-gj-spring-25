using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] protected AudioSO _so = null;
    [SerializeField] protected bool _playOnStart = false;

    private void Start()
    {
        if (_playOnStart)
        {
            Play();
        }
    }

    public virtual void Play()
    {
        _so.Play();
    }
}
