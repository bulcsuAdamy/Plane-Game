using System.Collections;
using TMPro;
using UnityEngine;

public class LevelCountDownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdowntext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gameObject.SetActive(false); 
    }

    public void StartCountdown(System.Action onComplete)
    {
        gameObject.SetActive(true);
        StartCoroutine(CountDownRoutine(onComplete));
    }

    IEnumerator CountDownRoutine(System.Action onComplete)
    {
        if (countdowntext == null)
        {
            Debug.Log("CountdownText not assigned");
            yield break;
        }
        for(int i=3; i > 0; i--)
        {
            countdowntext.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdowntext.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        onComplete?.Invoke();
    }
}
