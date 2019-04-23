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
    float currentRatio = 1;

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
        ratio = Mathf.Clamp(ratio, 0, 1);
        currentRatio = Mathf.Lerp(currentRatio, ratio, Time.deltaTime * lerpSpeed);
        bar.rectTransform.localScale = new Vector2(currentRatio, bar.rectTransform.localScale.y);
    }

}
