using UnityEngine;

public class EnemyHitParticles : MonoBehaviour
{
    public static EnemyHitParticles Instance;
    ParticleSystem hitParticles;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            hitParticles = GetComponent<ParticleSystem>();
        }
        else
            Destroy(gameObject);
    }
    public void Play(Vector3 position)
    {
        transform.position = position;
        hitParticles.Play();
    }
}
