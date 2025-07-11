using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    public UnityEngine.ParticleSystem m_enemyHitParticles;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    public void PlayEnemyHitParticles(Vector3 position)
    {
        m_enemyHitParticles.transform.position = position;
        m_enemyHitParticles.Play();
    }
}
