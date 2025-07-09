using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        FollowPath,
        FollowPlayer,
        Knockedback,
        Dead
    }
    public State m_state;
    public float m_enemyDetectPlayerDistance = 5f;

    EnemyFollowPath m_enemyFollowPath;
    EnemyFollowPlayer m_enemyFollowPlayer;
    EnemyHealth m_enemyHealth;
    EnemyKnockedback m_enemyKnockedback;

    Transform m_playerTransform;
    private void Awake()
    {
        m_enemyFollowPath = GetComponent<EnemyFollowPath>();
        m_enemyFollowPlayer = GetComponent<EnemyFollowPlayer>();
        m_enemyHealth = GetComponent<EnemyHealth>();
        m_enemyKnockedback = GetComponent<EnemyKnockedback>();

        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

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
        if (state == m_state) return;
        m_state = state;

        switch (state)
        {
            case State.FollowPath:
                {
                    m_enemyFollowPath.enabled = true;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyHealth.enabled = true;
                    m_enemyKnockedback.enabled = true;
                }
                break;
            case State.FollowPlayer:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = true;
                    m_enemyHealth.enabled = true;
                    m_enemyKnockedback.enabled = true;
                }
                break;
            case State.Knockedback:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyHealth.enabled = true;
                    m_enemyKnockedback.enabled = true;
                }
                break;
            case State.Dead:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyFollowPlayer.enabled = false;
                    m_enemyHealth.enabled = false;
                    m_enemyKnockedback.enabled = false;
                }
                break;
        }
    }
}
