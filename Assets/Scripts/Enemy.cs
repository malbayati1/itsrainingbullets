using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 2.0f;
    private float minDistance = 1.0f;
    private float range;
    public float health = 5.0f;
   

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health = health - 1;
            Destroy(col.gameObject);
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
   
    }
}
