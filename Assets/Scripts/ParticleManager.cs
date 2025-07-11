using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    public ParticleSystem m_hitParticles;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    public void PlayHitParticles(Vector3 position, Color color)
    {
        m_hitParticles.transform.position = position;
        var main = m_hitParticles.main;
        main.startColor = color;
        m_hitParticles.Play();
    }
}
