using UnityEngine;
public class SlashAttack : MonoBehaviour
{
    public int attackDamage = 1;
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.5f;
    public float knockbackDamping = 5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(attackDamage);
        }

        EnemyKnockbacked enemyKnockbacked = collision.GetComponent<EnemyKnockbacked>();
        if (enemyKnockbacked != null)
        {
            enemyKnockbacked.Knockbacked((Vector2)transform.position,
                knockbackForce, knockbackDuration, knockbackDamping);
        }
    }
}