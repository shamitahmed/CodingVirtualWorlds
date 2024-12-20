using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using DG.Tweening;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int scoreCount;
    public int comboCount;
    public int pinFallCountAlley1;
    public int pinFallCountAlley2;
    public int pinFallCountAlley3;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //ResetScore();
        //ResetCombo();
    }
    public void IncreaseScore(int score)
    {
        scoreCount += score;
        UIManager.Instance.txtScore.text = "Score: " + scoreCount.ToString();
        UIManager.Instance.txtScore.rectTransform.DOScale(new Vector3(1.2f,1.2f,1.2f),0.25f).SetLoops(2,LoopType.Yoyo);
    }
    public void IncreaseCombo()
    {
        comboCount++;
        UIManager.Instance.txtCombo.text = "Combo: " + comboCount.ToString();
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
