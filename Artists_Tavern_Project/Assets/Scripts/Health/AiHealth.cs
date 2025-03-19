using System.Collections;
using UnityEngine;

public class AiHealth : HealthBehaviour
{
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        //StartCoroutine(Die_Routine());
    }

    private IEnumerator Die_Routine()
    {
        yield return null;
        Destroy(gameObject);
    }
}
