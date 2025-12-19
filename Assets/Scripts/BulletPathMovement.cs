using UnityEngine;

public class BulletPathMovement : MonoBehaviour
{
    Transform[] waypoints;
    int waypointIndex = 0;

    [SerializeField] float moveSpeed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = GetComponentsInParent<Transform>();
        transform.position = waypoints[1].position;
        waypointIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (waypointIndex >= waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetPos = waypoints[waypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);

        if (transform.position == targetPos)
        {
            waypointIndex++;
        }
    }
}
