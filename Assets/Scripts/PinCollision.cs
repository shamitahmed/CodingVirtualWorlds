using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollision : MonoBehaviour
{
    public bool hit;
    public int scoreToGive = 10;
    public int alleyID;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("alley") && !hit)
        {
            hit = true;
            transform.parent.GetComponent<MeshRenderer>().material = GameManager.Instance.pinDedMat;

            if(alleyID == 0)
                ScoreManager.instance.pinFallCountAlley1 += 1;
            if (alleyID == 1)
                ScoreManager.instance.pinFallCountAlley2 += 1;
            if (alleyID == 2)
                ScoreManager.instance.pinFallCountAlley3 += 1;

            if (ScoreManager.instance.pinFallCountAlley1 >= 10)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.perfectStrike;
                SoundManager.instance.audioSource.Play();

                StartCoroutine(UIManagerBowling.Instance.PerfectStrikeRoutine());

                ScoreManager.instance.pinFallCountAlley1 = 0;
                Destroy(GameManager.Instance.pinObjectAlleys[0]);
                //spawn new set of 10 pins
                GameManager.Instance.SpawnPins(0);
            }

            if (ScoreManager.instance.pinFallCountAlley2 >= 10)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.perfectStrike;
                SoundManager.instance.audioSource.Play();

                StartCoroutine(UIManagerBowling.Instance.PerfectStrikeRoutine());

                ScoreManager.instance.pinFallCountAlley2 = 0;
                Destroy(GameManager.Instance.pinObjectAlleys[1]);
                //spawn new set of 10 pins
                GameManager.Instance.SpawnPins(1);
            }

            if (ScoreManager.instance.pinFallCountAlley3 >= 10)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.perfectStrike;
                SoundManager.instance.audioSource.Play();

                StartCoroutine(UIManagerBowling.Instance.PerfectStrikeRoutine());

                ScoreManager.instance.pinFallCountAlley3 = 0;
                Destroy(GameManager.Instance.pinObjectAlleys[2]);
                //spawn new set of 10 pins
                GameManager.Instance.SpawnPins(2);
            }

            UIManagerBowling.Instance.ScoreIncrease(scoreToGive);
            SoundManager.instance.audioSource.clip = SoundManager.instance.dropBall;
            SoundManager.instance.audioSource.Play();
        }
    }

}
