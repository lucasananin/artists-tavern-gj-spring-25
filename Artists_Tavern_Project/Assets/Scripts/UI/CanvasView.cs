using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasView : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup = null;
    [SerializeField] float _fadeDuration = 0.3f;

    private float _lastAlpha = 0;
    private float _targetAlpha = 0;
    private float _timer = 0;

    protected virtual void Update()
    {
        if (_canvasGroup.alpha == _targetAlpha) return;

        _timer += Time.unscaledDeltaTime * (1f / _fadeDuration);
        _canvasGroup.alpha = Mathf.Lerp(_lastAlpha, _targetAlpha, _timer);
    }

    public virtual void Show()
    {
        _timer = 0;
        _targetAlpha = 1;
        _lastAlpha = _canvasGroup.alpha;
        _canvasGroup.blocksRaycasts = true;
    }

    public virtual void Hide()
    {
        _timer = 0;
        _targetAlpha = 0;
        _lastAlpha = _canvasGroup.alpha;
        _canvasGroup.blocksRaycasts = false;
    }

    public void InstantShow()
    {
        _timer = 1;
        _targetAlpha = 1;
        _lastAlpha = 1;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void InstantHide()
    {
        _timer = 0;
        _targetAlpha = 0;
        _lastAlpha = 0;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    public bool IsVisible()
    {
        return _canvasGroup.alpha > 0;
    }
}
