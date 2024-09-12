using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int scoreCount;
    public int comboCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ResetScore();
        ResetCombo();
    }
    public void IncreaseScore(int score)
    {
        scoreCount += score;
        UIManager.Instance.txtScore.text = "Score: " + scoreCount.ToString();
    }
    public void IncreaseCombo()
    {
        comboCount++;
        UIManager.Instance.txtCombo.text = "Score: " + comboCount.ToString();
    }
    public void ResetScore()
    {
        scoreCount = 0;
        UIManager.Instance.txtScore.text = "Score: " + scoreCount.ToString();
    }
    public void ResetCombo()
    {
        comboCount = 0;
        UIManager.Instance.txtCombo.text = "Combo: " + comboCount.ToString();
    }
}
