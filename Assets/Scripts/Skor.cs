using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skor : MonoBehaviour
{
   

   [SerializeField] private Text scoreText;
   [SerializeField] private Text panelScoreText;
   [SerializeField] private Text panelHighScoreText;
   
   private int score;
   private int highScore;

   [SerializeField] private GameObject New;
    
    
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        panelScoreText.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScoreText.text = highScore.ToString();

    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            panelScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore",highScore);
            New.SetActive(false);
        }
    }

    public int GetScore()
    {
        return score;
    }

   
    
}
