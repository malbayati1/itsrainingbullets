using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_KeyboardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D m_rigidbody2D;
    [SerializeField] protected float player_speed;
    [SerializeField] protected float response_multiplier;
    private Vector2 direction;

    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            direction += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            direction += new Vector2(0, -1);
        if (Input.GetKey(KeyCode.D))
            direction += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.A))
            direction += new Vector2(-1, 0);
        //m_rigidbody2D.velocity = direction * player_speed;
        if (direction != Vector2.zero)
        {
            m_rigidbody2D.velocity = Vector3.Lerp(m_rigidbody2D.velocity, direction * player_speed, response_multiplier * Time.deltaTime);
        }
        else
        {
            m_rigidbody2D.velocity = Vector3.Lerp(m_rigidbody2D.velocity, direction * player_speed, response_multiplier * 3 * Time.deltaTime);
        } //Improves responsiveness for stopping instead of floating to a stop

    }
}
