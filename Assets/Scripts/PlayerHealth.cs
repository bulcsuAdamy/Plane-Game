using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    int currentHealth;
    public int CurrentHealth => currentHealth;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        FindAnyObjectByType<HealthUI>()?.UpdateHealth();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

}
