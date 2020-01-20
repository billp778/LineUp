using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public Rigidbody2D rigidbody2;

    private Transform food;
    private Transform floor;
    private Vector2 target;
    private Vector2 self;

	
	void Start () {

        food = GameObject.FindGameObjectWithTag("Food").transform;
        floor = GameObject.FindGameObjectWithTag("Floor").transform;
        target = new Vector2(food.position.x, food.position.y);
        self = new Vector2(transform.position.x, transform.position.y);
        var heading = target - self;
        rigidbody2.AddForce(heading.normalized * speed, ForceMode2D.Impulse);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            DestroyProjectile();
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            DestroyProjectile();
            Destroy(collision.gameObject);
            
        }
       
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }



}
