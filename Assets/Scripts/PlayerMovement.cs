using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float m_moveSpeed = 5.0f;

    SpriteRenderer m_spriteRenderer;
    Animator m_animator;
    Rigidbody2D m_rigidbody;

    Vector2 m_moveAmount = Vector2.zero;
    bool m_isMoving = false;

    void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        m_rigidbody.linearVelocity = m_moveAmount * m_moveSpeed;

        if (m_moveAmount.sqrMagnitude > 0)
        {
            m_isMoving = true;
            
            if (m_moveAmount.x > 0)
            {
                m_spriteRenderer.flipX = false;
            }
            else if (m_moveAmount.x < 0)
            {
                m_spriteRenderer.flipX = true;
            }
        }
        else
        {
            m_isMoving = false;
        }
        m_animator.SetBool("isMoving", m_isMoving);
        
    }
    public void OnMove(InputValue value)
    {
        m_moveAmount = value.Get<Vector2>();
    }
}
