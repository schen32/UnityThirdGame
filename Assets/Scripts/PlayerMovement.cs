using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    enum MoveState
    {
        Idle,
        Moving
    }

    public float m_moveSpeed = 5.0f;

    SpriteRenderer m_spriteRenderer;
    Animator m_animator;
    Rigidbody2D m_rigidbody;

    Vector2 m_moveAmount = Vector2.zero;
    MoveState playerMoveState = MoveState.Idle;

    void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        FlipToFaceCursor();
    }
    void FlipToFaceCursor()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (mouseWorldPos.x > transform.position.x)
            m_spriteRenderer.flipX = false;
        else if (mouseWorldPos.x < transform.position.x)
            m_spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        m_rigidbody.linearVelocity = m_moveAmount * m_moveSpeed;

        if (m_moveAmount.sqrMagnitude > 0)
            playerMoveState = MoveState.Moving;
        else
            playerMoveState = MoveState.Idle;

        m_animator.SetBool("isMoving", playerMoveState == MoveState.Moving);
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        m_moveAmount = context.ReadValue<Vector2>();
    }
}
