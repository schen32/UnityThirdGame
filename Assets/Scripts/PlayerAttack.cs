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

    public GameObject m_slashAttackPrefab;
    public float m_slashAttackDuration = 0.5f;
    public float m_slashAttackCooldown = 0.5f;

    AttackState m_slashAttackState = AttackState.Ready;
    bool m_isSlashAttackHeld = false;

    Animator m_animator;
    SpriteRenderer m_spriteRenderer;
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (m_isSlashAttackHeld && m_slashAttackState == AttackState.Ready)
        {
            StartCoroutine(DoSlashAttack());
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            m_isSlashAttackHeld = true;
        }
        else if (context.canceled)
        {
            m_isSlashAttackHeld = false;
        }
        
    }
    IEnumerator DoSlashAttack()
    {
        m_slashAttackState = AttackState.Attacking;

        AudioManager.Instance.PlaySlashAttackSound();
        m_animator.SetTrigger("SlashAttack");

        Vector3 slashAttackSpawnPos = new Vector3(transform.position.x, transform.position.y + m_spriteRenderer.size.y / 2);
        GameObject slashAttack = Instantiate(m_slashAttackPrefab, slashAttackSpawnPos,
            Quaternion.identity, transform);

        SpriteRenderer slashSpriteRenderer = slashAttack.GetComponent<SpriteRenderer>();
        slashSpriteRenderer.flipX = m_spriteRenderer.flipX;

        yield return new WaitForSeconds(m_slashAttackDuration);
        m_slashAttackState = AttackState.Cooldown;

        Destroy(slashAttack);

        yield return new WaitForSeconds(m_slashAttackCooldown);
        m_slashAttackState = AttackState.Ready;
    }
}
