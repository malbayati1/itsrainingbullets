using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        facePlayer();
    }

    void facePlayer()
    {
        if (Time.timeScale == 1f)
        {
            Vector3 playerPosition = FindClosest().position;

            Vector2 direction = new Vector2(
                playerPosition.x - transform.position.x,
                playerPosition.y - transform.position.y
                );

            transform.up = direction;
        }
    }

    Transform FindClosest()
    {
        Transform p1 = null;
        Transform p2 = null;

        if (GameObject.Find("Player1") != null) p1 = GameObject.Find("Player1").transform;
        if (GameObject.Find("Player2") != null) p2 = GameObject.Find("Player2").transform;

        if (p1 == null) { return p2; }
        else if (p2 == null) { return p1; }

        if ((p1.position - this.transform.position).magnitude < (p2.position - this.transform.position).magnitude)
        {
            return p1;
        }
        else
        {
            return p2;
        }
    }
}
