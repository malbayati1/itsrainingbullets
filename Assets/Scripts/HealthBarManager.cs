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

    private void Update()
    {
        if (playerOne != null)
        {
            UpdateBar(playerOneBar, playerOne);
        }

        if (playerTwo != null)
        {
            UpdateBar(playerTwoBar, playerTwo);
        }
    }

    void UpdateBar (Image bar, Health player)
    {
        float ratio = player.GetHealthRatio();
        //Mathf.Lerp()
        bar.rectTransform.localScale = new Vector2(ratio, bar.rectTransform.localScale.y);
    }

}
