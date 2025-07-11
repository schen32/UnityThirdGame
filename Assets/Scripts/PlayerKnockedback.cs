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
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration)
    {
        StartCoroutine(KnockedbackCoroutine(rigidbody,
            hitFromPos, knockbackForce, knockbackDuration));
    }
    public IEnumerator KnockedbackCoroutine(Rigidbody2D rigidbody,
        Vector2 hitFromPos, float knockbackForce, float knockbackDuration)
    {
        m_playerState.PushState(PlayerState.State.Knockedback);

        yield return KnockbackManager.Instance.Knockback(rigidbody, hitFromPos, knockbackForce, knockbackDuration);

        m_playerState.PopState();
    }
}
