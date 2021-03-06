﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_MouseShooting : MonoBehaviour
{


    private int FrameCount;
    [SerializeField] protected int frames_between_shot;
    private bool DoShoot = false;
    [SerializeField] protected Player1_Projectile projectile;
    const KeyCode FIREBUTTON = KeyCode.Mouse0;
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
        if (Input.GetKey(FIREBUTTON))
        {
            DoShoot = true;
        }
        if (DoShoot && FrameCount % frames_between_shot == 0)
        {
            Player1_Projectile new_projectile = Instantiate(projectile, transform.position, Quaternion.Euler(CalculateRotation()));
        }
        DoShoot = false;
    }



    Vector3 CalculateRotation()
    {
        Vector3 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 difference = Input.mousePosition - playerPos;
        float bulletAng = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Vector3 bulletVector = new Vector3(0, 0, bulletAng - 90);

        return bulletVector;
    }

    
}
