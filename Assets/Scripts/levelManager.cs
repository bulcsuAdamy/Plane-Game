using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;

    int currentLevel = 1; 
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

    public void StartLevel2()
    {
        currentLevel = 2;
        Debug.Log("Level 2 started");
    }

    public bool IsLevel2()
    {
        return currentLevel == 2;
    }

}
