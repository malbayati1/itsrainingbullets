using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] protected float explosion_life;
    [SerializeField] protected float explosion_growth;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<Transform>().gameObject, explosion_life);
    }

    // Update is called once per frame
    void Update()
    {
        float adjusted_scale = Time.deltaTime * explosion_growth;
        transform.localScale += new Vector3(adjusted_scale, adjusted_scale, 0);
    }
}
