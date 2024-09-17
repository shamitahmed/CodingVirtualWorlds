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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSpectrum.transform.localScale = new Vector3(4,6,4);
        Debug.Log(musicSource.clip.length);
    }

}
