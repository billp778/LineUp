using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] foodPrefab;

    int randomSpawnPoint;
    int randomFood;

    public static bool spawnAllowed;

	void Start () {

        spawnAllowed = true;
        InvokeRepeating("SpawnFood", 0f, 3f);

	}

    void SpawnFood()
    {

        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomFood = Random.Range(0, foodPrefab.Length);
            Instantiate(foodPrefab[randomFood], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }

    }
	

}