using System.Collections;
using UnityEngine;

public class BombShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 6f;
    [SerializeField] float minFireDelay = 1f;
    [SerializeField] float maxFireDelay = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Obstacle shooter started on" + gameObject.name);
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => levelManager.instance.IsLevel2());
            float waitTime = Random.Range(minFireDelay, maxFireDelay);
            yield return new WaitForSeconds(waitTime);

            Fire();
        }
    }
    
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if(rb!= null)
        {
            rb.linearVelocity = Vector2.down*bulletSpeed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
