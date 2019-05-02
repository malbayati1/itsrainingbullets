using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float response_multiplier;
    [SerializeField] protected float health = 5.0f;
    private Transform target;
    private Vector2 target_vector;
    private Rigidbody2D m_rigidbody2D;
    //private float minDistance = 1.0f;
    //private float range;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
        //GameObject go = GameObject.FindGameObjectWithTag("Player");
        //target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosest();
        target_vector = (target.position - transform.position).normalized * response_multiplier;
        m_rigidbody2D.AddForce(target_vector);
        m_rigidbody2D.velocity.Normalize();
        m_rigidbody2D.velocity = m_rigidbody2D.velocity * movementSpeed;
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Explosion_Small"))
        {
            health = health - 2;
            Vector2 force_vector = transform.position - col.transform.position;
            m_rigidbody2D.AddForce(force_vector * 5,ForceMode2D.Impulse);
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.CompareTag("Explosion_Large"))
        {
            health = health - 3;
            Vector2 force_vector = transform.position - col.transform.position;
            m_rigidbody2D.AddForce(force_vector * 15, ForceMode2D.Impulse);
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.CompareTag("Explosion_Triggered"))
        {
            health = health - 2;
            Vector2 force_vector = transform.position - col.transform.position;
            m_rigidbody2D.AddForce(force_vector * 10, ForceMode2D.Impulse);
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            health = health - 1;
            Destroy(col.gameObject);
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    public Vector2 getTargetVector()
    {
        return target_vector;
    }
}
