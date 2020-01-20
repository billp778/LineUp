using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public static int food;
    public static int bomb;
    public static int cannonIndex;
    public static int cannonBall;

    public bool waiting;

    void Start () {
        food = 0;
        bomb = 0;
        cannonIndex = 0;
        cannonBall = 0;
        
        waiting = false;
    }
	
	
	void Update () {

        if(waiting == false)
        {
            Time.timeScale = 1.0f;
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            food += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bomb")
        {
            bomb += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "CannonBall")
        {
            cannonBall += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SlowPowerUp")
        {
            waiting = true;
            SlowTime();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "DestroyCannon")
        {


            Cannon cannonManager = GameObject.Find("Cannons").GetComponent<Cannon>();
            cannonManager.DisableForSeconds(cannonIndex, 10f);
            cannonIndex++;
            Destroy(collision.gameObject);

            if (cannonIndex >= cannonManager.cannons.Length)
            {
                cannonIndex = 0;
            }

            /*
            GameObject go2 = GameObject.Find("Cannon (2)");
            GameObject go3 = GameObject.Find("Cannon (3)");
            GameObject go4 = GameObject.Find("Cannon (4)");

            if (cannons == 3)
            {
                Destroy(go4.gameObject);
                Destroy(collision.gameObject);
            }

            if (cannons == 2)
            {
                Destroy(go3.gameObject);
                cannons = 3;
                Destroy(collision.gameObject);
            }

            if (cannons == 1)
            {
                Destroy(go2.gameObject);
                cannons = 2;
                Destroy(collision.gameObject);
            }

            if (cannons == 0)
            {
                cannon1.DisableForSeconds(2f);
                cannons = 1;
                Destroy(collision.gameObject);
            }
            */

        }

    }
    

    private void SlowTime()
    {
        
        if(waiting == true)
        {
            Time.timeScale = .5f;
        }
        Wait();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        waiting = false;
    }


}
