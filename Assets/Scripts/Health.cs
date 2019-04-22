using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth;

    public float GetHealthRatio ()
    {
        return ((float)health / (float)maxHealth);
    }

}
