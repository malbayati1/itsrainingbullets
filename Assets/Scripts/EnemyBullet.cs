using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //[SerializeField] protected float bulletLife = 5f;
    //private Vector2 target;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(GetComponent<Transform>().gameObject, bulletLife);
        rb = GetComponent<Rigidbody2D>();
        //target = GetComponentInParent<EnemyShooting>().targetPosition;
        Transform target = FindClosest();
        moveDirection = (target.position - transform.position).normalized * moveSpeed;
        rb.velocity = moveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Debug.Log("Hit a player");
            collision.GetComponent<Health>().health -= 10;
            Destroy(gameObject);
        } else if (collision.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }

    Transform FindClosest()
    {
        Transform p1 = null;
        Transform p2 = null;

        if (GameObject.Find("Player1") != null) p1 = GameObject.Find("Player1").transform;
        if (GameObject.Find("Player2") != null) p2 = GameObject.Find("Player2").transform;

        if (p1 == null) { return p2; }
        else if (p2 == null) { return p1; }

        if ((p1.position - this.transform.position).magnitude < (p2.position - this.transform.position).magnitude)
        {
            return p1;
        }
        else
        {
            return p2;
        }
    }

}
