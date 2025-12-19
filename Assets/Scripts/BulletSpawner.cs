using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 2f;
    [SerializeField] int numberOfBullets = 10;
    [SerializeField] float startDelay = 3f;
    float xMin;
    float xMax;
    int direction = 1;

    [SerializeField] GameObject pointGiverPrefab;
    [SerializeField] float pointGiverChance = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void MoveSpawner()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (transform.position.x <= xMin || transform.position.x >= xMax)
        {
            direction *= -1;
        }
    }

    void SetUpBoundaries()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }
    
    void SpawnObstacle()
    {
        GameObject prefabToSpawn;

        if (Random.value < pointGiverChance)
        {
            prefabToSpawn = pointGiverPrefab;
        }
        else
        {
            prefabToSpawn = bulletPrefab;
        }

        GameObject obj = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down* bulletSpeed;
        }
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(startDelay);
        for (int i = 0; i < numberOfBullets; i++)
        {
            SpawnObstacle();

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Start()
    {
        SetUpBoundaries();
        StartCoroutine(SpawnBullets());
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpawner();
        SpawnBullets();
    }
}
