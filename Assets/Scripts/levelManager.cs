using System.Collections;
using System.Threading;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;

    int currentLevel = 1;
    bool level2Started = false;

    LevelCOuntDownUI countdownUI;

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
            return;
        }
        countdownUI = Resources.FindObjectsOfTypeAll<LevelCOuntDownUI>()[0];
    }

    public void StartLevel2WithCountdown()
    {
        if (level2Started) return;

        level2Started = true;

        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            player.SetCanMove(false);
        }

        countdownUI.StartCountdown(() =>
        {
            currentLevel = 2;

            if (player != null)
            {
                player.SetCanMove(true);
            }
            Debug.Log("Level 2 started");
        });


    }
    public bool IsLevel2()
    {
        return currentLevel == 2;
    }

}
