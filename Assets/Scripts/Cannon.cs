using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public GameObject[] cannons;
    public Transform[] spawnPoints;
    GameObject currentPoint;

    int randomSpawnPoint;

    [Header("Stats")]
    public float startTimeBtwShots;
    private float timeBtwShots;

    [Header("References")]
    public Transform Food;
    public GameObject projectile;

	void Start () {

        timeBtwShots = startTimeBtwShots;
	}
	
	
	void Update () {

        if(GameObject.FindGameObjectWithTag("Food"))
        {
            if (timeBtwShots <= 0)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
          
                if (cannons[randomSpawnPoint].active)
                {
                    Instantiate(projectile, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }

            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        
		
	}

    public void DisableForSeconds (int cannonNumber, float seconds)
    {
        cannons[cannonNumber].SetActive(false);
        StartCoroutine(ReEnableCannon(cannonNumber, seconds));
    }

    IEnumerator ReEnableCannon (int cannonNumber, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cannons[cannonNumber].SetActive(true);
    }
}
