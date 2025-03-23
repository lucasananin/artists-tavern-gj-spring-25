using System.Collections;
using UnityEngine;

public class HowToView : CanvasView
{
    [SerializeField] float _time = 5f;

    private IEnumerator Start()
    {
        InstantShow();
        yield return new WaitForSeconds(_time);
        Hide();
    }
}
