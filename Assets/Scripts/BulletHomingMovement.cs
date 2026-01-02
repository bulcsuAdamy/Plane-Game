using UnityEngine;

public class BulletHomingMovement : MonoBehaviour
{
    [SerializeField] float speed = 6f;

    Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player player = FindAnyObjectByType<Player>();

        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        moveDirection = (player.transform.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
