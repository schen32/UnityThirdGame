using UnityEngine;
public class EnemyFollowPlayer : MonoBehaviour
{
    public float m_enemyMoveSpeed = 2f;

    Transform m_playerTransform;
    Rigidbody2D m_rigidbody;
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        Vector2 toPlayer = ((Vector2)m_playerTransform.position - m_rigidbody.position).normalized;
        m_rigidbody.linearVelocity = Vector2.Lerp(m_rigidbody.linearVelocity, toPlayer * m_enemyMoveSpeed, 0.1f);

        if (m_rigidbody.linearVelocity.x >= 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
