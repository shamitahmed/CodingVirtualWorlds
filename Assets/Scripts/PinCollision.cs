using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollision : MonoBehaviour
{
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("alley") && !hit)
        {
            hit = true;
            ScoreManager.instance.pinFallCount += 1;
            if (ScoreManager.instance.pinFallCount >= 10)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.perfectStrike;
                SoundManager.instance.audioSource.Play();

                StartCoroutine(UIManagerBowling.Instance.PerfectStrikeRoutine());
                ScoreManager.instance.pinFallCount = 0;
                Destroy(GameManager.Instance.pinObject);
                //spawn new set of 10 pins
                GameManager.Instance.SpawnPins();
            }

            UIManagerBowling.Instance.ScoreIncrease(10);
            SoundManager.instance.audioSource.clip = SoundManager.instance.dropBall;
            SoundManager.instance.audioSource.Play();
        }
    }

}
