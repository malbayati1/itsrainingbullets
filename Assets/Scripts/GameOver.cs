using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject playerOne;
    public GameObject playerTwo;

    public bool hi = false;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckGameOver())
        {
            hi = true;
            gameOverScreen.SetActive(true);
        }
    }


    bool CheckGameOver ()
    {
        if (playerOne.GetComponent<Health>().health == 0 && playerTwo.GetComponent<Health>().health == 0)
        {
            return true;
        }
        else if (playerOne == null && playerTwo == null)
        {
            return true;
        }
        return false;
    }
}
