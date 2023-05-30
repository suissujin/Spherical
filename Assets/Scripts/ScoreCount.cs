using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI dangerText;

    void Update()
    {
        float sunDistance = GameObject.Find("Player").GetComponent<CharacterCtrl>().sunDistance;
        scoreText.text = "Score: " + score.ToString();
        fuelText.text = "Fuel: " + Mathf.Round(GameObject.Find("Player").GetComponent<CharacterCtrl>().fuelAmount).ToString();
        dangerText.text = "Danger in: " + Mathf.Round(sunDistance).ToString();

        if (sunDistance > 500)
        {
            dangerText.color = Color.green;
        }
        else if (sunDistance > 100 && sunDistance <= 500)
        {
            dangerText.color = Color.yellow;
        }
        else if (sunDistance > 0 && sunDistance <= 100)
        {
            dangerText.color = Color.red;
        }
    }
}
