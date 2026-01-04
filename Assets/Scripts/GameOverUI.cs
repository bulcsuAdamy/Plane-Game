using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; //pauses game
    }
}
