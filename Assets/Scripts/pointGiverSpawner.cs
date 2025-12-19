using System.Collections;
using System.Drawing;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float padding = 1f;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 2f;
    [SerializeField] int totalPointGivers = 10;
    [SerializeField] float fallSpeed = 5f;
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
    
    void SpawnPointGiver()
    {
        GameObject pointGiver = Instantiate(pointGiverPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = pointGiver.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down* fallSpeed;
        }
    }

    IEnumerator SpawnPointGivers()
    {
        yield return new WaitForSeconds(startDelay);
        
        for (int i =0; i < totalPointGivers; i++)
        {
            SpawnPointGiver();

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }

        Level1Complete();
    }

    void Level1Complete()
    {
        levelManager.instance.StartLevel2();
    }
    void Start()
    {
        SetUpBoundaries();
        StartCoroutine(SpawnPointGivers());
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpawner();
        SpawnPointGivers();
    }
}
