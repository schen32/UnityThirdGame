using UnityEngine;

public class DamageNumbers : MonoBehaviour
{
    public static DamageNumbers Instance;

    public GameObject damageTextPrefab;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void SpawnDamageNumber(int damageAmount, Vector3 position)
    {
        GameObject dmgText = Instantiate(damageTextPrefab, position, Quaternion.identity, transform);
        dmgText.GetComponent<TMPro.TextMeshProUGUI>().text = damageAmount.ToString();
    }
}
