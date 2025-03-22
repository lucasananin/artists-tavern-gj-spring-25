using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource _prefab = null;
    [SerializeField] List<AudioSource> _sources = null;

    private void Awake()
    {
        PopulateList();
    }

    private void OnEnable()
    {
        AudioSO.OnPlay += PlayAudio;
    }

    private void OnDisable()
    {
        AudioSO.OnPlay -= PlayAudio;
    }

    private void PlayAudio(AudioSO _soValue)
    {
        var _source = _soValue.IsMusic ? _sources[0] : GetAvailableSource();
        _source.clip = _soValue.Clip;
        _source.loop = _soValue.IsMusic;
        _source.Play();
    }

    public AudioSource GetAvailableSource()
    {
        int _count = _sources.Count;

        for (int i = 1; i < _count; i++)
        {
            if (!_sources[i].isPlaying)
            {
                return _sources[i];
            }
        }

        var _instance = Instantiate(_prefab, transform);
        _sources.Add(_instance);
        return _instance;
    }

    private void PopulateList()
    {
        for (int i = 0; i < 10; i++)
        {
            var _instance = Instantiate(_prefab, transform);
            _sources.Add(_instance);
        }
    }
}
