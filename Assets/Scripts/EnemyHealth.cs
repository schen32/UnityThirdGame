using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;
    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
