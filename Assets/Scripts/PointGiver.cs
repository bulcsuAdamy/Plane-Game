using UnityEngine;

public class PointGiver : MonoBehaviour
{
    [SerializeField] int points = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            ScoreManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
