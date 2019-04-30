using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Projectile : MonoBehaviour
{
    [SerializeField] protected float projectileVelocity;
    [SerializeField] protected float projectileLife;
    [SerializeField] protected Explosion explosion1;
    [SerializeField] protected Explosion explosion2;
    [SerializeField] protected Explosion explosion3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<Transform>().gameObject, projectileLife);
        GameObject player = GameObject.Find("Player1");
        Vector3 player_velocity = player.GetComponent<Rigidbody2D>().velocity;
        Vector3 direction = player.transform.up;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = (direction * projectileVelocity) + player_velocity/25;
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Small Explosion");
            Vector3 offset_position = (transform.position + col.transform.position) / 2;
            Instantiate(explosion1, offset_position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Debug.Log("Large Explosion");
            Instantiate(explosion2, transform.position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Explosion_Large"))
        {
            Destroy(gameObject);
            Debug.Log("Triggered Explsion");
            Instantiate(explosion3, transform.position, Quaternion.identity);
        }
    }
}
