using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "CannonBall")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SlowPowerUp")
        {
            Destroy(collision.gameObject);
        }


    }
}
