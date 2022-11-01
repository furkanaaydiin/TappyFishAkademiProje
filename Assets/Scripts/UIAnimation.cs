using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimation : MonoBehaviour
{
    public static UIAnimation uıAnimation;
    private GameManager gameManager;
    
    public RectTransform getReady;
    public RectTransform gameOverPanel;

    private void Start()
    {
        // GETREADY OYUN BASINDA ACILDIGINDA 
        getReady.DOScale(Vector3.zero, 1f).From();
    }

    public void GetReadyAnim()
    {
        getReady.DOScale(Vector3.zero, 0.5f).OnComplete(
            () =>
            {
                gameManager.getReady.SetActive(false);
            } );
    }

    public void GameOverAnim()
    {
        gameOverPanel.DOScale(Vector3.zero, 0.5f).From();
    }

    public void RestartButton(RectTransform rectTransform)
    {
        rectTransform.DOScale(rectTransform.localScale * 1.25f, 1f).SetLoops(2,LoopType.Yoyo);
    }
}
