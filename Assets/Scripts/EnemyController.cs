using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //   range = Vector2.Distance(transform.position, target.position);

        //   if (range > minDistance)
        //   {
        //       Debug.Log(range);

      //  transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    //    }
    }
}
