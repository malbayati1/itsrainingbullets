using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Projectile : MonoBehaviour
{
    [SerializeField] protected float projectileVelocity;
    [SerializeField] protected float projectileLife;
    [SerializeField] protected Explosion_Small explosion1;
    [SerializeField] protected Explosion_Large explosion2;

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
        if (col.gameObject.CompareTag("Enemy")) //Small explosion
        {
            Destroy(gameObject);
            Debug.Log("Small Explosion");
            Instantiate(explosion1, col.gameObject.transform.position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Bullet")) //Large explosion
        {
            Destroy(gameObject);
            Debug.Log("Large Explosion");
            Instantiate(explosion2, col.gameObject.transform.position, Quaternion.identity);
        }
    }
}
