using UnityEngine;
using System.Collections;

public class bombSpawner : MonoBehaviour
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField] float bombSpeed = 5f;
    [SerializeField] int numberOfBombs = 10;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 2f;
    [SerializeField] float startDelay = 2f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float padding = 1f;

    float xMin;
    float xMax;
    int direction = 1;

    void Start()
    {
        SetUpBoundaries();
        StartCoroutine(SpawnBullets());
    }

    void Update()
    {
        MoveSpawner();
    }

    void MoveSpawner()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (transform.position.x <= xMin || transform.position.x >= xMax)
        {
            direction *= -1;
        }
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < numberOfBombs; i++)
        {
            SpawnBullet();

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnBullet()
    {
        GameObject bomb = Instantiate(
            bombPrefab,
            transform.position,
            Quaternion.identity
        );

        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down * bombSpeed;
        }
    }

    void SetUpBoundaries()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}

