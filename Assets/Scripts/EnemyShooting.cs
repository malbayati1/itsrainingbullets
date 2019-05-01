using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Enemy self;
    private bool reloaded;
    private float timer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRatePerFrame;
    [SerializeField] int bulletSpeed;

    // Start is called before the first frame update
    private Vector2 targetPosition;
    void Start()
    {
        self = this.GetComponent<Enemy>();
        reloaded = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloaded == true)
        {
            targetPosition = this.GetComponent<Enemy>().getTargetVector();
            Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            reloaded = false;
        }
        else if(timer >= fireRatePerFrame)
        {
            timer = 0;
            reloaded = true;
        }

        timer += fireRatePerFrame * Time.deltaTime;
      
    }

    public int getSpeed()
    {
        return bulletSpeed;
    }
}
