using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Skor))]
public class GameManager : MonoBehaviour
{
    public static Vector2 buttonLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject getReady;
    public GameObject score;

    public static int gameScore;
    public static bool gameStared;
    public Skor scorScripts;

    public UIAnimation uıAnimation;
    


    private void Awake()
    {
       
        buttonLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    protected virtual void Start()
    {
        gameOver = false;
        gameStared = false;
    }

    public void GameHasStared()
    {
        gameStared = true;
    }

    
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
       
    }
    
    
    
    
    
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        uıAnimation.GameOverAnim();
        score.SetActive(false);
        gameScore = scorScripts.GetScore();
    }
    

   
}
