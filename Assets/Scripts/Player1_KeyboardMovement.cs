using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_KeyboardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] protected float player_speed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
            direction += new Vector2(0, player_speed);
        if (Input.GetKey(KeyCode.S))
            direction += new Vector2(0, -player_speed);
        if (Input.GetKey(KeyCode.D))
            direction += new Vector2(player_speed, 0);
        if (Input.GetKey(KeyCode.A))
            direction += new Vector2(-player_speed, 0);
        rb.velocity = direction;
    }
}
