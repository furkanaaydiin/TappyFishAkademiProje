using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Medal : MonoBehaviour
{
    public Sprite metalMedal, bronzMedal, silverMedal, goldMedal;
     Image img;
    
    void Start()
    {
        img = GetComponent<Image>();
    }

    
    void Update()
    {
        int gameScore = GameManager.gameScore;

        if (gameScore > 0 && gameScore <= 2)
        {
            img.sprite = metalMedal;
        }
        if (gameScore > 2 && gameScore <= 6)
        {
            img.sprite = bronzMedal;
        }
        if (gameScore > 6 && gameScore <= 10)
        {
            img.sprite = silverMedal;
        }
        if (gameScore > 10)
        {
            img.sprite = goldMedal;
        }
    }
}
