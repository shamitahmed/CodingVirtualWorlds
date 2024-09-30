using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using DG.Tweening;
public class UIManagerEscape : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle musicToggle;
    public GameObject winPanel;
    public GameObject losePanel;


    // Start is called before the first frame update
    void Start()
    {
        musicToggle.onValueChanged.AddListener(delegate
        {
            MusicToggle(musicToggle);
        });

        volumeSlider.onValueChanged.AddListener((v) =>
        {
            SoundManagerEscape.instance.musicSource.volume = v;
        });
    }
    public void MusicToggle(Toggle tglValue)
    {
        SoundManagerEscape.instance.musicSource.enabled = tglValue.isOn;
    }
}
