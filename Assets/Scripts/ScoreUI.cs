using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + ScoreManager.instance.GetScore();
    }
}
