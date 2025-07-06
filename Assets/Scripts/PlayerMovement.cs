using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float m_moveSpeed = 5.0f;

    SpriteRenderer m_spriteRenderer;
    Animator m_animator;

    Vector2 m_moveAmount = Vector2.zero;
    bool m_isMoving = false;

    void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (m_moveAmount.sqrMagnitude > 0)
        {
            Vector3 direction = new Vector3(m_moveAmount.x, m_moveAmount.y, 0);
            transform.position += direction * m_moveSpeed * Time.deltaTime;
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
