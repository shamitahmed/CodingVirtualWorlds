using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerEscape : MonoBehaviour
{
    public static SoundManagerEscape instance;
    public AudioSource audioSource;
    public AudioSource musicSource;
    public GameObject audioSpectrum;
    public AudioClip openDrawer;
    public AudioClip breakMirror;
    public AudioClip lightSwitch;
    public AudioClip openDoor;
    public AudioClip waterDrop;
    public AudioClip teleport;
    public AudioClip footstep;
    public AudioClip dropObject;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

}
