using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Rotation : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        float directionX = Input.GetAxis("RightThumbstickX");
        float directionY = Input.GetAxis("RightThumbstickY");
        if (directionX != 0 || directionY != 0)
        {
            transform.up = new Vector2(directionX, directionY);
        }     
    }
}
