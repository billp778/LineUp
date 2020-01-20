using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerSpawner : MonoBehaviour {

    public Transform[] powerUpSpawnPoints;
    public GameObject[] itemDropPrefab;

    int randomSpawnPoint;
    int randomFood;

    public static bool spawnAllowed;

    void Start()
    {

        spawnAllowed = true;
        InvokeRepeating("SpawnPower", 1f, 10f);

    }

    void SpawnPower()
    {

        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, powerUpSpawnPoints.Length);
            randomFood = Random.Range(0, itemDropPrefab.Length);
            Instantiate(itemDropPrefab[randomFood], powerUpSpawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }

    }
}
