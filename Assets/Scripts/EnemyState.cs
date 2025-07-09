using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        Alive,
        Knockedback,
        Dead
    }

    public State m_state;

    EnemyFollowPath m_enemyFollowPath;
    EnemyHealth m_enemyHealth;
    EnemyKnockedback m_enemyKnockedback;
    void Awake()
    {
        m_enemyFollowPath = GetComponent<EnemyFollowPath>();
        m_enemyHealth = GetComponent<EnemyHealth>();
        m_enemyKnockedback = GetComponent<EnemyKnockedback>();

        SwitchStateTo(State.Alive);
    }
    public void SwitchStateTo(State state)
    {
        if (state == m_state) return;
        m_state = state;

        switch (state)
        {
            case State.Alive:
                {
                    m_enemyFollowPath.enabled = true;
                    m_enemyHealth.enabled = true;
                    m_enemyKnockedback.enabled = true;
                }
                break;
            case State.Knockedback:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyHealth.enabled = true;
                    m_enemyKnockedback.enabled = true;
                }
                break;
            case State.Dead:
                {
                    m_enemyFollowPath.enabled = false;
                    m_enemyHealth.enabled = false;
                    m_enemyKnockedback.enabled = false;
                }
                break;
        }
    }
}
