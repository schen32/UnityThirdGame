using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    public ParticleSystem m_burstParticles;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    public void PlayBurstParticles(Vector3 position, Color color)
    {
        m_burstParticles.transform.position = position;
        var main = m_burstParticles.main;
        main.startColor = color;
        m_burstParticles.Play();
    }
}
