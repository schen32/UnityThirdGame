using System.Collections;
using UnityEngine;
public class PlayerKnockedback : MonoBehaviour
{
    PlayerState m_playerState;
    void Awake()
    {
        m_playerState = GetComponent<PlayerState>();
    }
    public void Knockedback(Rigidbody2D rigidbody,
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        StartCoroutine(KnockedbackCoroutine(rigidbody,
            hitFromPos, knockbackForce, knockbackDuration, knockbackDamping));
    }
    public IEnumerator KnockedbackCoroutine(Rigidbody2D rigidbody,
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration, float knockbackDamping)
    {
        m_playerState.PushState(PlayerState.State.Knockedback);

        yield return KnockbackManager.Instance.Knockback(rigidbody, hitFromPos, knockbackForce, knockbackDuration, knockbackDamping);

        m_playerState.PopState();
    }
}
