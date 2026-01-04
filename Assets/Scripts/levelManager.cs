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
        if (countdownUI == null)
        {
            Debug.Log("Countdown UI not assigned in LevelManager");
            return;

        }
    
        if (player != null)
        {
            player.SetCanMove(false);
        }

        countdownUI.StartCountdown(StartLevel2);
    }

    void StartLevel2()
    {
        currentLevel = 2;

        Time.timeScale = 1f;
        if (player != null)
        {
            player.SetCanMove(true);

            Debug.Log("Level 2 started");
        }
    }
    public bool IsLevel2()
    {
        return currentLevel == 2;
    }

}
