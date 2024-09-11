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
    [Header("haptic")]
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;

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
                SoundManager.instance.audioSource.clip = SoundManager.instance.hitBall;
                SoundManager.instance.audioSource.Play();
                LeftControllerVibration(0.1f, 0.1f);
                Destroy(other.gameObject.transform.parent.gameObject);
            }

            if (isRightSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 1)
            {
                SoundManager.instance.audioSource.clip = SoundManager.instance.hitBall;
                SoundManager.instance.audioSource.Play();
                RightControllerVibration(0.1f, 0.1f);
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
        if (other.gameObject.CompareTag("saber"))
        {
            saberColliding = true;
            LeftControllerVibration(0.1f, 0.1f);
            RightControllerVibration(0.1f, 0.1f);
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
   
