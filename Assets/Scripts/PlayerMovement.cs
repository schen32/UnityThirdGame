using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float m_moveSpeed = 5.0f;

    SpriteRenderer m_spriteRenderer;
    Vector2 m_moveAmount = Vector2.zero;

    void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_moveAmount.sqrMagnitude > 0)
        {
            transform.position += new Vector3(m_moveAmount.x, m_moveAmount.y, 0) * m_moveSpeed * Time.deltaTime;
            
            if (m_moveAmount.x >= 0)
            {
                m_spriteRenderer.flipX = false;
            }
            else if (m_moveAmount.x < 0)
            {
                m_spriteRenderer.flipX = true;
            }
        }
        
    }
    public void OnMove(InputValue value)
    {
        m_moveAmount = value.Get<Vector2>();
    }
}
