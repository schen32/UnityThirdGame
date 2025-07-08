using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

    SpriteRenderer m_spriteRenderer;
    void Awake()
    {
        currentHealth = maxHealth;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damageAmount)
    {
        AudioManager.Instance.PlayHitEnemySound();

        Vector3 dmgTextPos = new Vector3(transform.position.x, transform.position.y + m_spriteRenderer.size.y);
        DamageNumbers.Instance.SpawnDamageNumber(damageAmount, dmgTextPos);

        EnemyHitParticles.Instance.Play(transform.position);

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
