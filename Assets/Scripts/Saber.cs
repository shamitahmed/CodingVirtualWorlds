using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.Burst.Intrinsics.X86.Avx;
using EzySlice;

public class Saber : MonoBehaviour
{
    public bool isLeftSaber;
    public bool isRightSaber;
    public bool saberColliding;
    public GameObject blastFX;
    public GameObject bombFX;
    [Header("slice")]
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;

    public GameObject target;
    public Material crossSectionMaterialL;
    public Material crossSectionMaterialR;
    public Material crossSectionMaterial;

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
    private void FixedUpdate()
    {
        //bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        //if (hasHit)
        //{
        //    GameObject target = hit.transform.gameObject;
        //    Slice(target);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {

            //CubeCut.Cut(other.transform, transform.position);
            //Debug.Log(GetComponent<Rigidbody>().velocity.x.ToString() + " , " + GetComponent<Rigidbody>().velocity.y.ToString());
            if (isLeftSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 0)//OK LEFT or BLUE
            {

                    SoundManager.instance.audioSource.clip = SoundManager.instance.right;
                    SoundManager.instance.audioSource.Play();
                    LeftControllerVibration(strength, duration);
                    GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                    Destroy(fx, 2f);

                    ScoreManager.instance.IncreaseScore(20);
                    ScoreManager.instance.IncreaseCombo();
                    Slice(other.gameObject);
                    Destroy(other.gameObject);

            }
            else if (isRightSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 1)//OK RIGHT or RED
            {
                    SoundManager.instance.audioSource.clip = SoundManager.instance.right;
                    SoundManager.instance.audioSource.Play();
                    RightControllerVibration(strength, duration);
                    GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                    Destroy(fx, 2f);

                    ScoreManager.instance.IncreaseScore(20);
                    ScoreManager.instance.IncreaseCombo();
                    Slice(other.gameObject);
                    Destroy(other.gameObject);
            }
            else if (isLeftSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 1)//Wrong LEFT
            {
                //UI + particle + haptic + audio feedback
                StartCoroutine(UIManager.Instance.MissedUIRoutine());
                SoundManager.instance.audioSource.clip = SoundManager.instance.wrong;
                SoundManager.instance.audioSource.Play();
                ScoreManager.instance.ResetCombo();
                LeftControllerVibration(strength, duration);
                GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                Destroy(fx, 2f);
                Slice(other.gameObject);
                Destroy(other.gameObject);
            }
            else if (isRightSaber && other.gameObject.GetComponent<BallCollision>().cubeID == 0)//Wrong RIGHT
            {
                //UI + particle + haptic + audio feedback
                StartCoroutine(UIManager.Instance.MissedUIRoutine());
                SoundManager.instance.audioSource.clip = SoundManager.instance.wrong;
                SoundManager.instance.audioSource.Play();
                ScoreManager.instance.ResetCombo();
                RightControllerVibration(strength, duration);
                GameObject fx = Instantiate(blastFX, other.transform.position, blastFX.transform.rotation);
                Destroy(fx, 2f);
                Slice(other.gameObject);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag("saber") && !saberColliding)
        {
            LeftControllerVibration(strength, duration / 2);
            RightControllerVibration(strength, duration / 2);
            saberColliding = true;
        }
        if (other.gameObject.CompareTag("bomb"))
        {
            //blast FX
            GameObject fx = Instantiate(bombFX, other.transform.position, bombFX.transform.rotation);
            Destroy(fx, 2f);
            SoundManager.instance.audioSource.clip = SoundManager.instance.bomb;
            SoundManager.instance.audioSource.Play();
            LeftControllerVibration(strength * 2, duration);
            RightControllerVibration(strength * 2, duration);
            ScoreManager.instance.ResetCombo();

            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("saber"))
        {
            saberColliding = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
      
    }
    private void OnCollisionExit(Collision other)
    {

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
    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        if (hull != null)
        {
            if (isLeftSaber) crossSectionMaterial = crossSectionMaterialL;
            else if (isRightSaber) crossSectionMaterial = crossSectionMaterialR;

            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedComponent(upperHull);
            upperHull.transform.DOMove(target.transform.position, 0.01f);
            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedComponent(lowerHull);
            lowerHull.transform.DOMove(target.transform.position, 0.01f);
            Destroy(target.transform.parent.gameObject);
            upperHull.transform.DOScale(upperHull.transform.localScale/2, 1f).SetDelay(1f);
            lowerHull.transform.DOScale(lowerHull.transform.localScale/2, 1f).SetDelay(1f);
            Destroy(upperHull, 2.5f);
            Destroy(lowerHull, 2.5f);
        }
    }
    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb= slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        //rb.AddForce(0, 1000, 0);
        rb.AddExplosionForce(1000, slicedObject.transform.position, 1f);
    }
}
   
