using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AudioSO", menuName = "Scriptable Objects/AudioSO")]
public class AudioSO : ScriptableObject
{
    [SerializeField] AudioClip _clip = null;
    [SerializeField] bool _isMusic = false;
    [SerializeField, Range(0f, 1f)] float _volume = 1;

    public static event UnityAction<AudioSO> OnPlay = null;

    public AudioClip Clip { get => _clip; }
    public bool IsMusic { get => _isMusic; }
    public float Volume { get => _volume; }

    public void Play()
    {
        OnPlay?.Invoke(this);
    }

    public float GetClipLength()
    {
        return _clip.length;
    }
}
