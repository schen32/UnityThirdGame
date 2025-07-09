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
    public State m_state;
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

        SwitchStateTo(State.FollowPath);
    }
    private void Update()
    {
        var enemyDistToPlayer = Vector3.Distance(transform.position, m_playerTransform.position);
        if (enemyDistToPlayer <= m_enemyDetectPlayerDistance && m_state == State.FollowPath)
        {
            SwitchStateTo(State.FollowPlayer);
        }
        else if (enemyDistToPlayer > m_enemyDetectPlayerDistance && m_state == State.FollowPlayer)
        {
            SwitchStateTo(State.FollowPath);
        }
    }
    public void SwitchStateTo(State state)
    {
        if (m_state == state || m_state == State.Dead) return;
        m_state = state;

        m_rigidbody.linearVelocity = Vector2.zero;

        switch (state)
        {
            case State.FollowPath:
                {
                    m_enemyFollowPath.enabled = true;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyAttack.enabled = false;
                }
                break;
            case State.FollowPlayer:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = true;
                    m_enemyAttack.enabled = true;
                }
                break;
            case State.Attacking:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyAttack.enabled = true;
                }
                break;
            case State.Knockedback:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyAttack.enabled = false;
                }
                break;
            case State.Dead:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyAttack.enabled = false;
                    m_enemyHealth.enabled = false;
                    m_enemyKnockedback.enabled = false;

                    m_circleCollider.enabled = false;
                }
                break;
        }
    }
}
