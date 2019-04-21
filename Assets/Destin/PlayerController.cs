using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }


    public void CheckMovement ()
    {
        float hor = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(hor, ver, 0));
    }

}
