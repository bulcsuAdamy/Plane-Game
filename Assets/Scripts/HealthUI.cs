using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] PlayerHealth playerhealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UpdateHealth(); 
    }

    public void UpdateHealth()
    {
        int currentHealth = playerhealth.CurrentHealth;

        for (int i = 0; i<hearts.Length; i++)
        {
            hearts[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
        }
    }
}
