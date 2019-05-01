using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private EnemyShooting shooter;
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        shooter = this.GetComponent<EnemyShooting>();
        speed = shooter.getSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
