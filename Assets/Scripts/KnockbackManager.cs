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
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        Vector2 hitDirection = (rigidbody.position - hitFromPos).normalized;

        float originalLinearDamping = rigidbody.linearDamping;
        rigidbody.linearDamping = knockbackDamping;

        rigidbody.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);
        rigidbody.linearDamping = originalLinearDamping;
    }
}
