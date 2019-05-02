using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Projectile : MonoBehaviour
{
    [SerializeField] protected float projectileVelocity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player2");
        Vector3 player_velocity = player.GetComponent<Rigidbody2D>().velocity;
        Vector3 direction = player.transform.up;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = (direction * projectileVelocity) + player_velocity/10;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
