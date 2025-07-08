using System.Collections;
using UnityEngine;

public class EnemyKnockbacked : MonoBehaviour
{
    EnemyFollowPath m_enemyFollowPath;
    Rigidbody2D m_rigidbody;
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_enemyFollowPath = GetComponent<EnemyFollowPath>();
    }
    public void Knockbacked(Vector2 hitFromPos, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        Vector2 hitDirection = (m_rigidbody.position - hitFromPos).normalized;
        StartCoroutine(ApplyKnockback(hitDirection, knockbackForce, knockbackDuration, knockbackDamping));
    }
    IEnumerator ApplyKnockback(Vector2 hitDirection, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        m_enemyFollowPath.enabled = false;

        float originalLinearDamping = m_rigidbody.linearDamping;
        m_rigidbody.linearDamping = knockbackDamping;

        m_rigidbody.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        m_rigidbody.linearDamping = originalLinearDamping;
        m_enemyFollowPath.enabled = true;
    }
}
