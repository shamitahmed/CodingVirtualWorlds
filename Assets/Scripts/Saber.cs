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
    public GameObject bombFX;
    [Header("haptic")]
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    public float strength = 0.2f;
    public float duration = 0.2f;
    [Header("cut direction")]
    public int hitDirection;
    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            if (Vector3.Dot(transform.forward, other.contacts[0].normal) < 0)
            {
                Debug.Log("up");
                hitDirection = 0;
            }
            else if (Vector3.Dot(transform.forward, other.contacts[0].normal) > 0)
            {
                Debug.Log("down");
                hitDirection = 2;
            }        
            else if (Vector3.Dot(transform.right, other.contacts[0].normal) < 0)
            {
                Debug.Log("left");
                hitDirection = 1;
            }
            else if (Vector3.Dot(transform.right, other.contacts[0].normal) > 0)
            {
                Debug.Log("right");
                hitDirection = 3;
            }


            //CubeCut.Cut(other.transform, transform.position);
            //Debug.Log(GetComponent<Rigidbody>().velocity.x.ToString() + " , " + GetComponent<Rigidbody>().velocity.y.ToString());
            if (isLeftSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 0)//OK LEFT or BLUE
            {
                if(hitDirection == other.gameObject.GetComponent<BallCollision>().directionID)
                {
                    SoundManager.instance.audioSource.clip = SoundManager.instance.right;
                    SoundManager.instance.audioSource.Play();
                    LeftControllerVibration(strength, duration);
                    GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                    Destroy(fx, 2f);

                    ScoreManager.instance.IncreaseScore(20);
                    ScoreManager.instance.IncreaseCombo();
                    Destroy(other.gameObject.transform.parent.gameObject);
                }
                else
                {
                    //wrong direction
                    SoundManager.instance.audioSource.clip = SoundManager.instance.wrong;
                    SoundManager.instance.audioSource.Play();
                    LeftControllerVibration(strength, duration);
                    GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                    Destroy(fx, 2f);

                    ScoreManager.instance.IncreaseScore(10);
                    ScoreManager.instance.IncreaseCombo();
                    Destroy(other.gameObject.transform.parent.gameObject);

                }

            }
            else if (isRightSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 1)//OK RIGHT or RED
            {
                if (hitDirection == other.gameObject.GetComponent<BallCollision>().directionID)
                {
                    SoundManager.instance.audioSource.clip = SoundManager.instance.right;
                    SoundManager.instance.audioSource.Play();
                    RightControllerVibration(strength, duration);
                    GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                    Destroy(fx, 2f);

                    ScoreManager.instance.IncreaseScore(20);
                    ScoreManager.instance.IncreaseCombo();
                    Destroy(other.gameObject.transform.parent.gameObject);
                }
                else
                {
                    //wrong direction
                    SoundManager.instance.audioSource.clip = SoundManager.instance.wrong;
                    SoundManager.instance.audioSource.Play();
                    RightControllerVibration(strength, duration);
                    GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                    Destroy(fx, 2f);

                    ScoreManager.instance.IncreaseScore(10);
                    ScoreManager.instance.IncreaseCombo();
                    Destroy(other.gameObject.transform.parent.gameObject);

                }
            }
            else if (isLeftSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 1)//Wrong LEFT
            {
                //UI + particle + haptic + audio feedback
                StartCoroutine(UIManager.Instance.MissedUIRoutine());
                SoundManager.instance.audioSource.clip = SoundManager.instance.wrong;
                SoundManager.instance.audioSource.Play();
                ScoreManager.instance.ResetCombo();
                LeftControllerVibration(strength, duration);
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            else if (isRightSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 0)//Wrong RIGHT
            {
                //UI + particle + haptic + audio feedback
                StartCoroutine(UIManager.Instance.MissedUIRoutine());
                SoundManager.instance.audioSource.clip = SoundManager.instance.wrong;
                SoundManager.instance.audioSource.Play();
                ScoreManager.instance.ResetCombo();
                RightControllerVibration(strength, duration);
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
        if (other.gameObject.CompareTag("saber") && !saberColliding)
        {
            LeftControllerVibration(strength, duration/2);
            RightControllerVibration(strength, duration/2);
            saberColliding = true;
        }
        if (other.gameObject.CompareTag("bomb"))
        {
            //blast FX
            GameObject fx = Instantiate(bombFX, other.transform.position, bombFX.transform.rotation);
            Destroy(fx, 2f);
            SoundManager.instance.audioSource.clip = SoundManager.instance.bomb;
            SoundManager.instance.audioSource.Play();
            LeftControllerVibration(strength*2, duration);
            RightControllerVibration(strength*2, duration);
            ScoreManager.instance.ResetCombo();

            Destroy(other.gameObject.transform.parent.gameObject);
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
   
