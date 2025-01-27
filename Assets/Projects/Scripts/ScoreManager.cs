using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    int _score;
    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreText.text = value.ToString();
        }
    }

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void AddScore(int val)
    {
        score += val;
    }

    public int CalculateScore(float dist)
    {
        if (dist >= 0.325f)
        {
            return 1;
        }
        else if (dist >= 0.15f)
        {
            return 3;
        }
        else
        {
            return 5;
        }
    }
}
