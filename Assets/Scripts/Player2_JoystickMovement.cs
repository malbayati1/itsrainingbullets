using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_JoystickMovement : MonoBehaviour
{
    //Player movement using the left thumbstick, axes set up for a wired Xbox 360 gamepad.  Might need minor changes for other gamepads.


    private Rigidbody2D m_rigidbody2D;
    [SerializeField] protected float player_speed;
    [SerializeField] protected float response_multiplier;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        direction.x = Input.GetAxis("LeftThumbstickX");
        direction.y = Input.GetAxis("LeftThumbstickY");
        if (direction != Vector2.zero)
        {
            m_rigidbody2D.velocity = Vector3.Lerp(m_rigidbody2D.velocity, direction * player_speed, response_multiplier * Time.deltaTime);
        }
        else
        {
            m_rigidbody2D.velocity = Vector3.Lerp(m_rigidbody2D.velocity, direction * player_speed, response_multiplier * 3 * Time.deltaTime);
        }   //Improves responsiveness for stopping instead of floating to a stop
    }
}
