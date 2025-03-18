using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    [SerializeField] PlayerEnergy _energy = null;
    [SerializeField] Image _fill = null;

    private void OnEnable()
    {
        _energy.OnValueChanged += UpdateVisuals;
    }

    private void OnDisable()
    {
        _energy.OnValueChanged -= UpdateVisuals;
    }

    private void UpdateVisuals(PlayerEnergy _energy)
    {
        _fill.fillAmount = _energy.GetNormalizedValue();
    }
}
