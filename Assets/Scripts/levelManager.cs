using System.Collections;
using System.Threading;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;

    int currentLevel = 1;
    Player player;

    [SerializeField] LevelCountDownUI countdownUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        Time.timeScale = 1f;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartLevel2WithCountdown()
    {
        Debug.Log("Starting Level 2 Countdown");

        if (player != null)
            player.SetCanMove(false);

        if (countdownUI != null)
            countdownUI.StartCountdown(StartLevel2);
        else
            Debug.LogError("Countdown UI not assigned!");
    }

    void StartLevel2()
    {
        Debug.Log("Level 2 started");

        currentLevel = 2;
        Time.timeScale = 1f;

        if (player != null)
        {
            player.SetCanMove(true);
        }
    }
    public bool IsLevel2()
    {
        return currentLevel == 2;
    }

}
