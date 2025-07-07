using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    enum AttackState
    {
        Ready,
        Attacking,
        Cooldown
    }

    public float slashAttackDuration = 0.5f;
    public float slashAttackCooldown = 0.5f;

    AttackState slashAttackState = AttackState.Ready;

    Animator m_animator;
    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    public void OnAttack(InputValue value)
    {
        if (slashAttackState != AttackState.Ready) return;

        StartCoroutine(DoSlashAttack());
    }
    IEnumerator DoSlashAttack()
    {
        m_animator.SetTrigger("SlashAttack");
        slashAttackState = AttackState.Attacking;

        yield return new WaitForSeconds(slashAttackDuration);
        slashAttackState = AttackState.Cooldown;

        yield return new WaitForSeconds(slashAttackCooldown);
        slashAttackState = AttackState.Ready;
    }
}
