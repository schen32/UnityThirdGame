using System.Collections;
using UnityEngine;

public class DamageNumberManager : MonoBehaviour
{
    public static DamageNumberManager Instance;
    public Transform m_parentCanvasTransform;
    public float m_damageNumberDuration = 0.5f;
    public float m_yOffset = 1f;

    public GameObject damageTextPrefab;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void SpawnDamageNumber(int damageAmount, Vector2 position, Color color)
    {
        Vector2 dmgTextPos = position + new Vector2(0, m_yOffset);
        GameObject dmgText = Instantiate(damageTextPrefab, dmgTextPos, Quaternion.identity, m_parentCanvasTransform);
        dmgText.GetComponent<TMPro.TextMeshProUGUI>().text = damageAmount.ToString();
        dmgText.GetComponent<TMPro.TextMeshProUGUI>().color = color;

        StartCoroutine(DestroyDamageNumber(dmgText));
    }
    IEnumerator DestroyDamageNumber(GameObject damageNumber)
    {
        yield return new WaitForSeconds(m_damageNumberDuration);
        Destroy(damageNumber);
    }
}
