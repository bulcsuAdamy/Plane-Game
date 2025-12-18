using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
