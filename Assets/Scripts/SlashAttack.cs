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
        if (enemyHealth & enemyHealth.enabled)
        {
            enemyHealth.TakeDamage(attackDamage);
        }

        EnemyKnockedback enemyKnockedback = collision.GetComponent<EnemyKnockedback>();
        if (enemyKnockedback && enemyKnockedback.enabled)
        {
            enemyKnockedback.Knockbacked((Vector2)transform.position,
                knockbackForce, knockbackDuration, knockbackDamping);
        }
    }
}