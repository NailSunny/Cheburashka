using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawner : MonoBehaviour
{
    public GameObject OrangePrefab;
    public List<Transform> spawnPoints;
    public float SpawnTime = 2f;
    void Start()
    {
        InvokeRepeating("SpawnOrange", 0f, SpawnTime);

    }
    void SpawnOrange()
    {
        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Точки появления не назначены!");
            return;
        }
        int SpawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[SpawnPointIndex];
        Instantiate(OrangePrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
