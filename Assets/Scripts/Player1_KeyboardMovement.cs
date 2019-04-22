﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_KeyboardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, 0);
        }
    }
}
