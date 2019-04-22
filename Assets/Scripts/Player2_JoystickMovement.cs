using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_JoystickMovement : MonoBehaviour
{
    //Player movement using the left thumbstick, axes set up for a wired Xbox 360 gamepad.  Might need minor changes for other gamepads.


    private Rigidbody2D rb;
    [SerializeField] protected float player_speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float directionX = Input.GetAxis("LeftThumbstickX");
        float directionY = Input.GetAxis("LeftThumbstickY");
        rb.velocity = new Vector2(directionX, directionY) * player_speed;
    }
}
