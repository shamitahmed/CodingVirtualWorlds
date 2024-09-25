using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class UIManagerBowling : MonoBehaviour
{
    public static UIManagerBowling Instance;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtStrike;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    public void ScoreIncrease(int score)
    {
        txtScore.gameObject.SetActive(true);
        if (ScoreManager.instance.pinFallCount < 10)
            txtStrike.gameObject.SetActive(false);
        ScoreManager.instance.scoreCount += score;
        txtScore.text = ScoreManager.instance.scoreCount.ToString();
        txtScore.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.25f).SetLoops(2, LoopType.Yoyo);
    }
    public IEnumerator PerfectStrikeRoutine()
    {
        txtScore.gameObject.SetActive(false);
        txtStrike.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        txtScore.gameObject.SetActive(true);
        txtStrike.gameObject.SetActive(false);
    }
}
