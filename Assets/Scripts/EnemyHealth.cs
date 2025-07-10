using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int m_maxHealth = 3;
    int m_currentHealth;

    SpriteRenderer m_spriteRenderer;
    Animator m_animator;
    EnemyState m_enemyState;
    void Awake()
    {
        m_currentHealth = m_maxHealth;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_enemyState = GetComponent<EnemyState>();
    }

    public int TakeDamage(int damageAmount)
    {
        AudioManager.Instance.PlayHitEnemySound();

        Vector3 dmgTextPos = new Vector3(transform.position.x, transform.position.y + m_spriteRenderer.size.y);
        DamageNumbers.Instance.SpawnDamageNumber(damageAmount, dmgTextPos);

        EnemyHitParticles.Instance.Play(transform.position);

        m_currentHealth -= damageAmount;
        if (m_currentHealth <= 0)
        {
            m_animator.SetTrigger("DeathTrigger");
            m_enemyState.PushState(EnemyState.State.Dead);
        }
        return m_currentHealth;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
