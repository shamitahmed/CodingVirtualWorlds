using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public AudioSource musicSource;
    public GameObject audioSpectrum;
    public AudioClip hitBall;
    public AudioClip breakBall;
    public AudioClip spawnBall;
    public AudioClip wrong;
    public AudioClip right;
    public AudioClip bomb;
    public AudioClip hitPin;
    public AudioClip bowling;
    public AudioClip dropBall;
    public AudioClip perfectStrike;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        if(audioSpectrum!=null) audioSpectrum.transform.localScale = new Vector3(4,6,4);
    }

}
