using System.Collections;
using TMPro;
using UnityEngine;

public class LevelCOuntDownUI : MonoBehaviour
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
