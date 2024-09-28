using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandButton : MonoBehaviour
{
    public int buttonID;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            isPressed = !isPressed;
            SoundManagerEscape.instance.audioSource.clip = SoundManagerEscape.instance.lightSwitch;
            SoundManagerEscape.instance.audioSource.Play();

            if (isPressed)
                transform.DOMoveY(transform.position.y - 0.1f, 0.2f);
            else
                transform.DOMoveY(transform.position.y + 0.1f, 0.2f);

            if(buttonID == 0)
            {
                if (isPressed)
                    GameManagerEscape.Instance.lampLight.SetActive(true);
                else
                    GameManagerEscape.Instance.lampLight.SetActive(false);
            }
        }
    }
}
