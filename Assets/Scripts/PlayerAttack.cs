using System.Collections;
using Unity.VisualScripting;
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

    public GameObject slashAttackPrefab;
    public float slashAttackDuration = 0.5f;
    public float slashAttackCooldown = 0.5f;

    AttackState slashAttackState = AttackState.Ready;
    bool isSlashAttackHeld = false;

    Animator m_animator;
    SpriteRenderer m_spriteRenderer;
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
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

        Vector3 slashAttackSpawnPos = new Vector3(transform.position.x, transform.position.y + m_spriteRenderer.size.y / 2);

        GameObject slashAttack = Instantiate(slashAttackPrefab, slashAttackSpawnPos,
            Quaternion.identity, transform);

        SpriteRenderer slashSpriteRenderer = slashAttack.GetComponent<SpriteRenderer>();
        slashSpriteRenderer.flipX = m_spriteRenderer.flipX;

        yield return new WaitForSeconds(slashAttackDuration);
        slashAttackState = AttackState.Cooldown;

        Destroy(slashAttack);

        yield return new WaitForSeconds(slashAttackCooldown);
        slashAttackState = AttackState.Ready;
    }
}
