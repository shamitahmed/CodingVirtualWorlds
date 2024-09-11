using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject blastFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blade"))
        {
            GameObject fx = Instantiate(blastFX,transform.position, blastFX.transform.rotation);
            Destroy(fx, 2f);
            //SoundManager.instance.audioSource.clip = SoundManager.instance.breakBall;
            //SoundManager.instance.audioSource.Play();
            Destroy(transform.parent.gameObject);
        }
    }
}
