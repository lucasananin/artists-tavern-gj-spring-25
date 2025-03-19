using UnityEngine;

public class AiHealth : HealthBehaviour
{
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        //Debug.Log($"a", this);
    }
}
