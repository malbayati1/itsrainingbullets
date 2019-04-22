using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }


    void MoveBullet ()
    {
        transform.Translate(new Vector3(0, bulletSpeed * Time.deltaTime, 0));
    }
}
