using System.Collections;
using UnityEngine;

public class MusicPlayer : AudioPlayer
{
    [SerializeField] AudioSO _loopVersion = null;

    public override void Play()
    {
        StartCoroutine(Play_Routine());
    }

    private IEnumerator Play_Routine()
    {
        _so.Play();
        yield return new WaitForSeconds(_so.GetClipLength());
        _loopVersion.Play();

    }
}
