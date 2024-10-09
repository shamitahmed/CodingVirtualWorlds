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
    public Slider volumeSlider;
    public Toggle musicToggle;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtStrike;
    public Button btnOpenTut;
    public Button btnCloseTut;
    public GameObject tutObject;
    [Header("Store")]
    public Button btnHat1;
    public Button btnHat2;
    public Button btnHat3;
    public GameObject hat1;
    public GameObject hat2;
    public GameObject hat3;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        musicToggle.onValueChanged.AddListener(delegate
        {
            MusicToggle(musicToggle);
        });

        volumeSlider.onValueChanged.AddListener((v) =>
        {
            SoundManager.instance.musicSource.volume = v;
        });

        btnCloseTut.onClick.AddListener(()  =>  CloseTut());
        btnOpenTut.onClick.AddListener(() => OpenTut());

        btnHat1.onClick.AddListener(() => Hat1());
        btnHat2.onClick.AddListener(() => Hat2());
        btnHat3.onClick.AddListener(() => Hat3());
    }
    public void MusicToggle(Toggle tglValue)
    {
        SoundManager.instance.musicSource.enabled = tglValue.isOn;
    }
    public void ScoreIncrease(int score)
    {
        txtScore.gameObject.SetActive(true);
        if (ScoreManager.instance.pinFallCountAlley1 < 10 && ScoreManager.instance.pinFallCountAlley2 < 10 && ScoreManager.instance.pinFallCountAlley3 < 10)
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
    public void CloseTut()
    {
        tutObject.SetActive(false);
        btnCloseTut.gameObject.SetActive(false);
        btnOpenTut.gameObject.SetActive(true);
    }
    public void OpenTut()
    {
        tutObject.SetActive(true);
        btnCloseTut.gameObject.SetActive(true);
        btnOpenTut.gameObject.SetActive(false);
    }
    public void Hat1()
    {
        hat1.SetActive(true);
        hat2.SetActive(false);
        hat3.SetActive(false);
    }
    public void Hat2()
    {
        hat1.SetActive(false);
        hat2.SetActive(true);
        hat3.SetActive(false);
    }
    public void Hat3()
    {
        hat1.SetActive(false);
        hat2.SetActive(false);
        hat3.SetActive(true);
    }
}
