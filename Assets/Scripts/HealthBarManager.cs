using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    public Image playerOneBar;
    public Image playerTwoBar;

    public Health playerOne;
    public Health playerTwo;

    public float lerpSpeed;

    float ratioOne = 1;
    float ratioTwo = 1;


    private void Start()
    {
        if (!playerOne) { playerOne = GameObject.Find("Player1").GetComponent<Health>(); }
        if (!playerTwo) { playerTwo = GameObject.Find("Player2").GetComponent<Health>(); }
    }

    private void Update()
    {
        if (playerOne != null)
        {
            ratioOne = UpdateBar(playerOneBar, playerOne, ratioOne);
        } 
        else
        {
            playerOneBar.rectTransform.localScale = new Vector2(0, playerOneBar.rectTransform.localScale.y);
        }

        if (playerTwo != null)
        {
            ratioTwo = UpdateBar(playerTwoBar, playerTwo, ratioTwo);
        }
        else
        {
            playerTwoBar.rectTransform.localScale = new Vector2(0, playerTwoBar.rectTransform.localScale.y);
        }
    }

    float UpdateBar (Image bar, Health player, float currentRatio)
    {
        float ratio = player.GetHealthRatio();
        ratio = Mathf.Clamp(ratio, 0, 1);
        currentRatio = Mathf.Lerp(currentRatio, ratio, Time.deltaTime * lerpSpeed);
        bar.rectTransform.localScale = new Vector2(currentRatio, bar.rectTransform.localScale.y);

        return currentRatio;
    }

}
