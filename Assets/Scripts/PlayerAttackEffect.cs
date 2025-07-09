using UnityEngine;
public class PlayerAttackEffect : MonoBehaviour
{
    public int m_attackDamage = 1;
    public float m_knockbackForce = 5f;
    public float m_knockbackDuration = 0.5f;
    public float m_knockbackDamping = 5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;

        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth & enemyHealth.enabled)
        {
            enemyHealth.TakeDamage(m_attackDamage);
        }

        EnemyKnockedback enemyKnockedback = collision.GetComponent<EnemyKnockedback>();
        if (enemyKnockedback && enemyKnockedback.enabled)
        {
            enemyKnockedback.Knockbacked((Vector2)transform.position,
                m_knockbackForce, m_knockbackDuration, m_knockbackDamping);
        }
    }
}