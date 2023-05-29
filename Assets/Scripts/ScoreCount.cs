using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
