using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text = null;
    [SerializeField] PlayerScore _score = null;

    private void OnEnable()
    {
        _score.OnValueChanged += UpdateVisuals;
    }

    private void UpdateVisuals()
    {
        _text.text = $"{_score.Score}";
    }
}
