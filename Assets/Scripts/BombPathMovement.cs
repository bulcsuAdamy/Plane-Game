using UnityEngine;

public class BulletPathMovement : MonoBehaviour
{
    Transform[] waypoints;
    int waypointIndex = 0;

    [SerializeField] float moveSpeed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform path = transform.parent;

        if (path == null)
        {
            Debug.LogError("Bomb has no path parent");
            Destroy(gameObject);
            return;
        }

        waypoints = new Transform[path.childCount];

        for(int i = 0; i < path.childCount; i++)
        {
            waypoints[i] = path.GetChild(i);
        }

        transform.position = waypoints[0].position;
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
