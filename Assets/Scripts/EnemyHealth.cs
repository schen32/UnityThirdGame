using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

    SpriteRenderer m_spriteRenderer;
    Animator m_animator;
    CircleCollider2D m_circleCollider;
    Rigidbody2D m_rigidbody;
    EnemyState m_enemyState;
    void Awake()
    {
        currentHealth = maxHealth;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_circleCollider = GetComponent<CircleCollider2D>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_enemyState = GetComponent<EnemyState>();
    }

    public int TakeDamage(int damageAmount)
    {
        AudioManager.Instance.PlayHitEnemySound();

        Vector3 dmgTextPos = new Vector3(transform.position.x, transform.position.y + m_spriteRenderer.size.y);
        DamageNumbers.Instance.SpawnDamageNumber(damageAmount, dmgTextPos);

        EnemyHitParticles.Instance.Play(transform.position);

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            m_animator.SetTrigger("DeathTrigger");
            m_circleCollider.enabled = false;
            m_rigidbody.linearVelocity = Vector2.zero;
            m_enemyState.SwitchStateTo(EnemyState.State.Dead);
        }
        return currentHealth;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
