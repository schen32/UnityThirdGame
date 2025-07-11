using System.Collections;
using UnityEngine;

public class EnemyKnockedback : MonoBehaviour
{
    EnemyState m_enemyState;
    void Awake()
    {
        m_enemyState = GetComponent<EnemyState>();
    }
    public void Knockedback(Rigidbody2D rigidbody,
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration)
    {
        StartCoroutine(KnockedbackCoroutine(rigidbody,
            hitFromPos, knockbackForce, knockbackDuration));
    }
    public IEnumerator KnockedbackCoroutine(Rigidbody2D rigidbody,
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration)
    {
        m_enemyState.PushState(EnemyState.State.Knockedback);

        yield return KnockbackManager.Instance.Knockback(rigidbody, hitFromPos, knockbackForce, knockbackDuration);

        m_enemyState.PopState();
    }
}
