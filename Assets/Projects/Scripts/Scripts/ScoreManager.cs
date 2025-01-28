using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalResesult;
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
        CancelInvoke(nameof(_UpdateFinalReset));
        score = 0;
        finalResesult.text = "";
    }

    public void AddScore(int val)
    {
        score += val;
        if (score > 15)
        {
            finalResesult.text = "YOU WIN";
        }
    }

    public void UpdateFinalReset()
    {
        Invoke(nameof(_UpdateFinalReset), 0.7f);
    }

    void _UpdateFinalReset()
    {
        if (score > 15)
        {
            finalResesult.text = "YOU WIN";
        }
        else 
        {
            finalResesult.text = "YOU Lost";
        }
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
