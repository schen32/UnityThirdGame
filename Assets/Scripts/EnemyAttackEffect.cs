using UnityEngine;
public class EnemyAttackEffect : MonoBehaviour
{
    public int m_attackDamage = 1;
    public float m_knockbackForce = 5f;
    public float m_knockbackDuration = 0.5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) return;

        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth & playerHealth.enabled)
        {
            playerHealth.TakeDamage(m_attackDamage);
        }

        PlayerKnockedback playerKnockedback = collision.GetComponent<PlayerKnockedback>();
        if (playerKnockedback && playerKnockedback.enabled)
        {
            playerKnockedback.Knockedback(collision.attachedRigidbody, transform.position,
                m_knockbackForce, m_knockbackDuration);
        }
    }
}