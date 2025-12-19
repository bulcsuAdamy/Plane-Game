using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] int damage = 2;

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
