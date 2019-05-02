using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth;
    private Rigidbody2D m_rigidbody2D;

    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
    public float GetHealthRatio ()
    {
        return ((float)health / (float)maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health = Mathf.Clamp(health - 2, 0, maxHealth);
        }
        if (collision.gameObject.CompareTag("Explosion_Small"))
        {
            health = Mathf.Clamp(health - 2, 0, maxHealth);
            Vector2 force_vector = transform.position - collision.transform.position;
            GetComponent<Rigidbody2D>().AddForce(force_vector * 5, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Explosion_Triggered"))
        {
            health = Mathf.Clamp(health - 2, 0, maxHealth);
            Vector2 force_vector = transform.position - collision.transform.position;
            GetComponent<Rigidbody2D>().AddForce(force_vector * 10, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Explosion_Large"))
        {
            health = Mathf.Clamp(health - 3, 0, maxHealth);
            Vector2 force_vector = transform.position - collision.transform.position;
            GetComponent<Rigidbody2D>().AddForce(force_vector * 15, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health = Mathf.Clamp(health - 1, 0, maxHealth);
            Vector2 force_vector = transform.position - collision.transform.position;
            GetComponent<Rigidbody2D>().AddForce(force_vector * 3, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health = Mathf.Clamp(health - 1, 0, maxHealth);
        }
    }
}
