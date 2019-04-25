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
    void FixedUpdate()
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
        Transform p1 = GameObject.Find("Player1").transform;
        Transform p2 = GameObject.Find("Player2").transform;
        
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
        if (col.gameObject.CompareTag("Missile"))
        {
            health = health - 2; //Temporary, once explosion is implemented, explosion will deal damage.
                                 //Plan to replace this code block with explosion damage implementation
                                 //Player1 projectile will handle instantiating an explosion on collision, missile itself deals no damage.
            Destroy(col.gameObject);
            Debug.Log("Small Explosion");
            //Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (col.gameObject.CompareTag("Bullet"))
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
}
