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

        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }
}
