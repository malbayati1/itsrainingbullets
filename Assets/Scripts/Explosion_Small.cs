using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Small : MonoBehaviour
{
    [SerializeField] protected float explosion_life;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<Transform>().gameObject, explosion_life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
