using System.Collections;
using UnityEngine;

public class KnockbackManager : MonoBehaviour
{
    public static KnockbackManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    public IEnumerator Knockback(Rigidbody2D rigidbody,
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration)
    {
        Vector2 hitDirection = (rigidbody.position - hitFromPos).normalized;
        rigidbody.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackDuration);
    }
}
