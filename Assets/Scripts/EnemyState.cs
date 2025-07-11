using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        FollowPath,
        FollowPlayer,
        Attacking,
        Knockedback,
        Dead
    }
    Stack<State> m_stateStack = new Stack<State>();
    public float m_enemyDetectPlayerDistance = 5f;

    EnemyFollowPath m_enemyFollowPath;
    EnemyFollowPlayer m_enemyFollowPlayer;
    EnemyAttack m_enemyAttack;
    EnemyHealth m_enemyHealth;
    EnemyKnockedback m_enemyKnockedback;

    Transform m_playerTransform;
    Rigidbody2D m_rigidbody;
    CircleCollider2D m_circleCollider;
    private void Awake()
    {
        m_enemyFollowPath = GetComponent<EnemyFollowPath>();
        m_enemyFollowPlayer = GetComponent<EnemyFollowPlayer>();
        m_enemyAttack = GetComponent<EnemyAttack>();
        m_enemyHealth = GetComponent<EnemyHealth>();
        m_enemyKnockedback = GetComponent<EnemyKnockedback>();

        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_circleCollider = GetComponent<CircleCollider2D>();

        PushState(State.FollowPath);
    }
    private void Update()
    {
        var enemyDistToPlayer = Vector3.Distance(transform.position, m_playerTransform.position);
        if (enemyDistToPlayer <= m_enemyDetectPlayerDistance && CurrentState() == State.FollowPath)
        {
            PushState(State.FollowPlayer);
        }
        else if (enemyDistToPlayer > m_enemyDetectPlayerDistance && CurrentState() == State.FollowPlayer)
        {
            PushState(State.FollowPath);
        }
    }
    public void PushState(State newState)
    {
        if (m_stateStack.Count > 0 && CurrentState() == State.Dead) return;

        m_stateStack.Push(newState);
        SwitchStateTo(newState);
    }

    public void PopState()
    {
        if (m_stateStack.Count > 0 && CurrentState() == State.Dead) return;

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

        m_enemyFollowPath.enabled = false;
        m_enemyFollowPlayer.enabled = false;
        m_enemyAttack.enabled = false;
        m_enemyHealth.enabled = true;
        m_enemyKnockedback.enabled = true;

        switch (state)
        {
            case State.FollowPath:
                {
                    m_enemyFollowPath.enabled = true;
                }
                break;
            case State.FollowPlayer:
                {
                    m_enemyFollowPlayer.enabled = true;
                    m_enemyAttack.enabled = true;
                }
                break;
            case State.Attacking:
                {
                    m_enemyAttack.enabled = true;
                }
                break;
            case State.Knockedback:
                {
                    
                }
                break;
            case State.Dead:
                {
                    m_enemyHealth.enabled = false;
                    m_enemyKnockedback.enabled = false;

                    m_circleCollider.enabled = false;
                }
                break;
        }
    }
}
