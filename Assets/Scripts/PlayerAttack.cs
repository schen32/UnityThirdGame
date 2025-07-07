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
    bool isSlashAttackHeld = false;

    Animator m_animator;
    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isSlashAttackHeld && slashAttackState == AttackState.Ready)
        {
            StartCoroutine(DoSlashAttack());
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isSlashAttackHeld = true;
        }
        else if (context.canceled)
        {
            isSlashAttackHeld = false;
        }
        
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
