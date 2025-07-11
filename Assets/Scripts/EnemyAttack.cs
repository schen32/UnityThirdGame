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
    public float m_attackWindup = 0.6f;
    public float m_attackDuration = 0.5f;
    public float m_attackCooldown = 0.5f;

    public float m_enemyAttackDistance = 2f;
    Transform m_playerTransform;

    AttackState m_attackState = AttackState.Ready;

    Animator m_animator;
    EnemyState m_enemyState;
    void Awake()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_animator = GetComponent<Animator>();
        m_enemyState = GetComponent<EnemyState>();
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
        m_enemyState.PushState(EnemyState.State.Attacking);

        m_attackState = AttackState.Windup;
        m_animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(m_attackWindup);
        m_attackState = AttackState.Attacking;

        AudioManager.Instance.PlayOrcAttackSound();
        GameObject attack = Instantiate(m_attackPrefab, transform.position, Quaternion.identity, transform);

        yield return new WaitForSeconds(m_attackDuration);
        m_attackState = AttackState.Cooldown;

        Destroy(attack);

        yield return new WaitForSeconds(m_attackCooldown);
        m_attackState = AttackState.Ready;

        m_animator.SetBool("isAttacking", false);
        m_enemyState.PopState();
    }
}
