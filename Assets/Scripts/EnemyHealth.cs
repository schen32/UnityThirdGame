using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int m_maxHealth = 3;
    int m_currentHealth;

    Animator m_animator;
    EnemyState m_enemyState;
    void Awake()
    {
        m_currentHealth = m_maxHealth;
        m_animator = GetComponent<Animator>();
        m_enemyState = GetComponent<EnemyState>();
    }

    public int TakeDamage(int damageAmount)
    {
        AudioManager.Instance.PlayHitEnemySound();
        DamageNumberManager.Instance.SpawnDamageNumber(damageAmount, transform.position, Color.white);
        ParticleManager.Instance.PlayBurstParticles(transform.position, Color.white);

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
