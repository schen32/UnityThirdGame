using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int m_maxHealth = 10;
    int m_currentHealth;

    Animator m_animator;
    PlayerState m_playerState;
    void Awake()
    {
        m_currentHealth = m_maxHealth;
        m_animator = GetComponent<Animator>();
        m_playerState = GetComponent<PlayerState>();
    }

    public int TakeDamage(int damageAmount)
    {
        AudioManager.Instance.PlayHitEnemySound();
        DamageNumberManager.Instance.SpawnDamageNumber(damageAmount, transform.position, Color.red);
        ParticleManager.Instance.PlayHitParticles(transform.position, Color.red);

        m_currentHealth -= damageAmount;
        //if (m_currentHealth <= 0)
        //{
        //    m_animator.SetTrigger("DeathTrigger");
        //    m_playerState.PushState(PlayerState.State.Dead);
        //}
        return m_currentHealth;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
