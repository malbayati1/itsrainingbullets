using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] protected float bulletLife = 3f;
    private Vector2 target;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<Transform>().gameObject, bulletLife);
        target = GetComponentInParent<EnemyShooting>().targetPosition;
        rb = GetComponent<Rigidbody2D>();

        moveDirection = (target - (Vector2)transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
