using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class LevelCountDownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void StartCountdown(Action onComplete)
    {
        gameObject.SetActive(true);
        StartCoroutine(CountDownRoutine(onComplete));
    }

    IEnumerator CountDownRoutine(Action onComplete)
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        onComplete?.Invoke();
    }
}
