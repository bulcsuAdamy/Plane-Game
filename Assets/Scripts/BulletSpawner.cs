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
    
    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * bulletSpeed;
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(startDelay);
        for (int i = 0; i < numberOfBullets; i++)
        {
            SpawnBullet();

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
