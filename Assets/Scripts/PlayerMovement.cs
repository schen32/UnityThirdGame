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
            m_spriteRenderer.color = Color.red;
        }
        else
        {
            m_spriteRenderer.color = Color.white;
        }
        
    }
    public void OnMove(InputValue value)
    {
        m_moveAmount = value.Get<Vector2>();
    }
}
