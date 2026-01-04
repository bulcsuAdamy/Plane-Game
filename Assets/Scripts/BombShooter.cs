using System.Collections;
using Unity.Mathematics;
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
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => levelManager.instance.IsLevel2());
            float waitTime = UnityEngine.Random.Range(minFireDelay, maxFireDelay);
            yield return new WaitForSeconds(waitTime);

            Debug.Log("Bomb firing bullet");
            Fire();
        }
    }
    
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, quaternion.identity);
        Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = (FindAnyObjectByType<Player>().transform.position - transform.position).normalized *bulletSpeed;
        }
    }

}
