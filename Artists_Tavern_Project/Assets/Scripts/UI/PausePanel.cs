using UnityEngine;

public class PausePanel : CanvasView
{
    private void Start()
    {
        InstantHide();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsVisible())
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }

        base.Update();
    }

    public void Pause()
    {
        InstantShow();
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        InstantHide();
        Time.timeScale = 1;
    }
}
