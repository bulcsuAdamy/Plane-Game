using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject ObstaclePrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int numberOfObstacles = 5;
    [SerializeField] float timeBetweenSpawns = 3f;

    public GameObject GetObstaclePrefab() => ObstaclePrefab;
    public GameObject GetPathPrefab() => pathPrefab;
    public int GetNumberOfObstacles() => numberOfObstacles;
    public float GetTimeBetweenSpawns() => timeBetweenSpawns;
}
