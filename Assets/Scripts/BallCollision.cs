using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject blastFX;
    public bool isCube;
    public int cubeID;
    public int directionID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blade"))
        {
            //miss + destroy

            //GameObject fx = Instantiate(blastFX,transform.position, blastFX.transform.rotation);
            //Destroy(fx, 2f);

            //SoundManager.instance.audioSource.clip = SoundManager.instance.breakBall;
            //SoundManager.instance.audioSource.Play();
            StartCoroutine(UIManager.Instance.MissedUIRoutine());
            ScoreManager.instance.ResetCombo();
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            SoundManager.instance.audioSource.clip = SoundManager.instance.dropBall;
            SoundManager.instance.audioSource.Play();
        }
    }
}
