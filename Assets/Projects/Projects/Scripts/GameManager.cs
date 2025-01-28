using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(this);
    }

    public Action onGameResets;

    public bool isGameStarted;
    public void StartGame()
    {
        ScoreManager.instance.ResetScore();
        SetIsGameStarted(true);
    }

    public void ResetGame()
    {
        ScoreManager.instance.ResetScore();
        onGameResets?.Invoke();
        SetIsGameStarted(false);
    }
    public void SetIsGameStarted(bool val)
    {
        isGameStarted = val;
    }


}

