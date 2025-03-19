using UnityEngine;

public class SpriteColorRandomizer : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer = null;

    [ContextMenu("Randomize()")]
    private void Randomize()
    {
        _renderer.color = Random.ColorHSV(0, 1, 0.5f, 1f, 0.5f, 1f);
    }
}
