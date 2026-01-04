using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] PlayerHealth playerhealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    public void UpdateHealth()
    {
        int currentHealth = playerhealth.CurrentHealth;

        for (int i = 0; i<hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < currentHealth);
        }
    }
}
