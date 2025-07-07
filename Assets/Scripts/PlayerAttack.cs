using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float slashAttackDuration = 0.5f;
    public float slashAttackCooldown = 0.5f;

    Animator m_animator;
    bool isDoingSlashAttack = false;
    bool isSlashAttackOnCooldown = false;
    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        m_animator.SetBool("isDoingSlashAttack", isDoingSlashAttack);
    }
    public void OnAttack(InputValue value)
    {
        if (isSlashAttackOnCooldown) return;

        StartCoroutine(DoSlashAttack());
    }
    IEnumerator DoSlashAttack()
    {
        isSlashAttackOnCooldown = true;

        isDoingSlashAttack = true;
        yield return new WaitForSeconds(slashAttackDuration);
        isDoingSlashAttack = false;

        yield return new WaitForSeconds(slashAttackCooldown);

        isSlashAttackOnCooldown = false;
    }
}
