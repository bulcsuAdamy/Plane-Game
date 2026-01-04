using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] int damage = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.bulletHit);
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
