using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Projectile : MonoBehaviour
{
    [SerializeField] protected float projectileVelocity;
    [SerializeField] protected float projectileLife;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<Transform>().gameObject, projectileLife);
        GameObject player = GameObject.Find("Player2");
        Vector3 player_velocity = player.GetComponent<Rigidbody2D>().velocity;
        Vector3 direction = player.transform.up;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = (direction * projectileVelocity) + player_velocity/10;
    }

    private void FixedUpdate()
    {
        
    }
}
