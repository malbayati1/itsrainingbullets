using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Enemy self;
    private bool reloaded;
    private float timer;
    public Vector2 targetPosition;
    [SerializeField] private GameObject bullet;
     private float fireRate;
     private float nextFire;

    // Start is called before the first frame update
    
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        self = this.GetComponent<Enemy>();
        targetPosition = self.getTargetVector();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfTimeToFire();
      
    }

    void checkIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(CalculateRotation()), this.transform);
            nextFire = Time.time + fireRate;
        }
    }
    private Vector3 CalculateRotation()
    {
        Vector3 enemyPos = self.transform.position;
        Vector3 difference = (Vector3)targetPosition - enemyPos;
        float bulletAng = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Vector3 bulletVector = new Vector3(0, 0, bulletAng - 90);

        return bulletVector;
    }

    
}
