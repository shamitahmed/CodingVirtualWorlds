using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Saber : MonoBehaviour
{
    public bool isLeftSaber;
    public bool isRightSaber;
    public bool saberColliding;
    public GameObject blastFX;
    [Header("haptic")]
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    public float strength = 0.2f;
    public float duration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            if (isLeftSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 0)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.breakBall;
                SoundManager.instance.audioSource.Play();
                LeftControllerVibration(strength,duration);
                GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                Destroy(fx, 2f);

                Destroy(other.gameObject.transform.parent.gameObject);
            }

            if (isRightSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 1)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.breakBall;
                SoundManager.instance.audioSource.Play();
                RightControllerVibration(strength,duration);
                GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                Destroy(fx, 2f);

                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
        if (other.gameObject.CompareTag("saber") && !saberColliding)
        {
            saberColliding = true;
            LeftControllerVibration(strength/2, duration/2);
            RightControllerVibration(strength/2, duration/2);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("saber"))
        {
            saberColliding = false;
        }
    }

    public void SendHaptic(XRBaseController controller, float amplitude, float duration)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
    }
    public void LeftControllerVibration(float amp, float dur)
    {
        SendHaptic(leftController, amp, dur);
    }


    public void RightControllerVibration(float amp, float dur)
    {
        SendHaptic(rightController, amp, dur);

    }
}
   
