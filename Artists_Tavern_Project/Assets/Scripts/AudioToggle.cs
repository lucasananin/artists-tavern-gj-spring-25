using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    [SerializeField] Toggle _toggle = null;

    private void Start()
    {
        _toggle.isOn = AudioListener.volume > 0;
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleVolume);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleVolume);
    }

    void ToggleVolume(bool _value)
    {
        AudioListener.volume = _value ? 1 : 0;
    }
}
