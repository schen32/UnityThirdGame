using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State
    {
        Alive,
        Knockedback,
        Dead
    }
    Stack<State> m_stateStack = new Stack<State>();

    PlayerMovement m_playerMovement;
    PlayerAttack m_playerAttack;
    PlayerKnockedback m_playerKnockedback;
    PlayerHealth m_playerHealth;

    Rigidbody2D m_rigidbody;
    CircleCollider2D m_circleCollider;
    private void Awake()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerAttack = GetComponent<PlayerAttack>();
        m_playerKnockedback = GetComponent<PlayerKnockedback>();
        m_playerHealth = GetComponent<PlayerHealth>();

        m_rigidbody = GetComponent<Rigidbody2D>();
        m_circleCollider = GetComponent<CircleCollider2D>();

        PushState(State.Alive);
    }
    public void PushState(State newState)
    {
        m_stateStack.Push(newState);
        SwitchStateTo(newState);
    }

    public void PopState()
    {
        if (m_stateStack.Count > 1)
        {
            m_stateStack.Pop();
            SwitchStateTo(CurrentState());
        }
    }
    public State CurrentState()
    {
        return m_stateStack.Peek();
    }
    private void SwitchStateTo(State state)
    {
        m_rigidbody.linearVelocity = Vector2.zero;

        m_playerMovement.enabled = true;
        m_playerAttack.enabled = true;
        m_playerKnockedback.enabled = true;
        m_playerHealth.enabled = true;

        switch (state)
        {
            case State.Alive:
                {
                    
                }
                break;
            case State.Knockedback:
                {
                    m_playerMovement.enabled = false;
                }
                break;
            case State.Dead:
                {
                    m_playerMovement.enabled = false;
                    m_playerAttack.enabled = false;
                    m_playerKnockedback.enabled = false;
                    m_playerHealth.enabled = false;

                    m_circleCollider.enabled = false;
                }
                break;
        }
    }
}
