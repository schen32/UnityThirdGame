using UnityEngine;
using UnityEngine.Rendering;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip hitEnemySound;
    public AudioClip hitPlayerSound;
    public AudioClip slashAttackSound;
    public AudioClip orcAttackSound;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.volume = volume;
        sfxSource.pitch = Random.Range(0.8f, 1.2f);
        sfxSource.PlayOneShot(clip);
    }
    public void PlayHitEnemySound()
    {
        PlaySFX(hitEnemySound, 0.2f);
    }
    public void PlayHitPlayerSound()
    {
        PlaySFX(hitPlayerSound, 0.2f);
    }

    public void PlaySlashAttackSound()
    {
        PlaySFX(slashAttackSound, 0.2f);
    }

    public void PlayOrcAttackSound()
    {
        PlaySFX(orcAttackSound, 0.2f);
    }
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
}
