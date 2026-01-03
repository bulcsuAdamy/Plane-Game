using System.Collections;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;

    int currentLevel = 1;
    bool level2Started = false;

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
    }

    public void StartLevel2WithDelay(float delay)
    {
        if (!level2Started)
        {
            StartCoroutine(Level2DelayRoutine(delay));
        }
        currentLevel = 2;

    }

    IEnumerator Level2DelayRoutine(float delay)
    {
        level2Started = true;
        Debug.Log("Level 2 started in " + delay + " second...");
        yield return new WaitForSeconds(delay);
    }
    public bool IsLevel2()
    {
        return currentLevel == 2;
    }

}
