using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAttack : MonoBehaviour
{
    enum AttackState
    {
        Ready,
        Windup,
        Attacking,
        Cooldown
    }

    public GameObject m_attackPrefab;
    public float m_attackWindup = 0.7f;
    public float m_attackDuration = 0.5f;
    public float m_attackCooldown = 0.5f;

    public float m_enemyAttackDistance = 2f;
    Transform m_playerTransform;

    AttackState m_attackState = AttackState.Ready;

    SpriteRenderer m_spriteRenderer;
    Animator m_animator;
    void Awake()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        var enemyDistToPlayer = Vector3.Distance(transform.position, m_playerTransform.position);
        if (enemyDistToPlayer <= m_enemyAttackDistance && m_attackState == AttackState.Ready)
        {
            StartCoroutine(DoAttack());
        }
    }
    IEnumerator DoAttack()
    {
        m_attackState = AttackState.Windup;
        m_animator.SetTrigger("AttackTrigger");

        yield return new WaitForSeconds(m_attackWindup);
        m_attackState = AttackState.Attacking;

        Vector3 attackSpawnPos = new Vector3(transform.position.x, transform.position.y + m_spriteRenderer.size.y / 2);
        GameObject attack = Instantiate(m_attackPrefab, attackSpawnPos, Quaternion.identity, transform);

        SpriteRenderer slashSpriteRenderer = attack.GetComponent<SpriteRenderer>();
        slashSpriteRenderer.flipX = m_spriteRenderer.flipX;

        yield return new WaitForSeconds(m_attackDuration);
        m_attackState = AttackState.Cooldown;

        Destroy(attack);

        yield return new WaitForSeconds(m_attackCooldown);
        m_attackState = AttackState.Ready;
    }
}
