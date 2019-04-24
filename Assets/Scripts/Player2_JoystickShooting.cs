using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_JoystickShooting : MonoBehaviour
{
    //Player Shooting using the right thumbstick, axes set up for a Wired Xbox 360 gamepad.
    

    private int FrameCount;
    [SerializeField] protected int frames_between_shot;
    private bool DoShoot = false;
    [SerializeField] protected Player2_Projectile projectile;
    //SerializeField] protected GameObject player_location;

    // Start is called before the first frame update
    void Start()
    {
        FrameCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FrameCount++;
        float directionX = Input.GetAxis("RightThumbstickX");
        float directionY = Input.GetAxis("RightThumbstickY");
        if (directionX != 0 || directionY != 0)
        {
            DoShoot = true;
        }
        if (DoShoot && FrameCount % frames_between_shot == 0)
        {
            Vector2 firing_vector = new Vector2(directionX, directionY);
            Player2_Projectile new_projectile = Instantiate(projectile, transform.position, Quaternion.identity);
        }
        DoShoot = false;
    }
}
