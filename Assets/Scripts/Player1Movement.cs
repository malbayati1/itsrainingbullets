using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
   //[SerializeField] private int speed;
    //private Rigidbody2D rb;
    //private Vector2 direction;
    //// Start is called before the first frame update
    void Start()
    {
        //rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();

        //if (direction.sqrMagnitude > 0)
        //{
        //    rb.velocity = (Vector3)direction * speed;
        //}
        //else
        //{
        //    rb.velocity = Vector2.zero;
        //}


    }

    //private void GetInput()
    //{
    //    direction = Vector2.zero;

    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        direction += Vector2.up;
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        direction += Vector2.left;
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        direction += Vector2.down;
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        direction += Vector2.right;
    //    }

    //    direction.Normalize();
    //}
}
