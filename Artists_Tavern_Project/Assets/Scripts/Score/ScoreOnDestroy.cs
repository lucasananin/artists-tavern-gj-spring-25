using UnityEngine;

public class ScoreOnDestroy : ScoreGiver
{
    private void OnDestroy()
    {
        SendScore();
    }
}
