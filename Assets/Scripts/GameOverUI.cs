using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (scoreText == null)
        {
            Debug.Log("ScoreText not assigned in GameOverUI");
            return;
        }

        scoreText.text = "Score: " + ScoreManager.instance.GetScore();
        gameObject.SetActive(true);
        Time.timeScale = 0f; //pauses game
    }
}
