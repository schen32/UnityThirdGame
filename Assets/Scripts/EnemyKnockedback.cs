using System.Collections;
using UnityEngine;

public class EnemyKnockedback : MonoBehaviour
{
    Rigidbody2D m_rigidbody;
    EnemyState m_enemyState;
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_enemyState = GetComponent<EnemyState>();
    }
    public void Knockbacked(Vector2 hitFromPos, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        Vector2 hitDirection = (m_rigidbody.position - hitFromPos).normalized;
        StartCoroutine(ApplyKnockback(hitDirection, knockbackForce, knockbackDuration, knockbackDamping));
    }
    IEnumerator ApplyKnockback(Vector2 hitDirection, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        var originalState = m_enemyState.m_state;
        m_enemyState.SwitchStateTo(EnemyState.State.Knockedback);

        float originalLinearDamping = m_rigidbody.linearDamping;
        m_rigidbody.linearDamping = knockbackDamping;

        m_rigidbody.linearVelocity = Vector2.zero;
        m_rigidbody.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);
        m_rigidbody.linearDamping = originalLinearDamping;

        m_enemyState.SwitchStateTo(originalState);
    }
}
