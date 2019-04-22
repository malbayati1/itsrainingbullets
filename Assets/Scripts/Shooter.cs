using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : PlayerController
{

    public GameObject bullet;

    bool firing = false;
    const KeyCode FIREBUTTON = KeyCode.Mouse0;

    public float fireDelay;
    float lastFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();
        CheckMovement();
    }

    void CheckFire ()
    {
        if (Input.GetKeyDown(FIREBUTTON))
        {
            firing = true;
        }
        else if (Input.GetKeyUp(FIREBUTTON))
        {
            firing = false;
        }


        if (firing)
        {
            if (lastFire >= fireDelay)
            {
                Fire ();
                lastFire = 0;
            }
            else
            {
                lastFire += Time.deltaTime;
            }
        }
    }


    void Fire ()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(CalculateRotation()));
    }

    Vector3 CalculateRotation ()
    {
        Vector3 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 difference = Input.mousePosition - playerPos;
        float bulletAng = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Vector3 bulletVector = new Vector3(0, 0, bulletAng - 90);

        return bulletVector;
    }
}
