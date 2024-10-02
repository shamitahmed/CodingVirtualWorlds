using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteractor : MonoBehaviour
{
    public int objectID;
    public bool followHand;

    public float moveSpeed = 5f; // Speed at which the follower moves towards the target
    private Vector3 lastTargetPosition;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (followHand)
        {
            if (target.transform.position != lastTargetPosition)
            {
                // Move towards the new position of the target
                //StartCoroutine(MoveFollower(target.transform.position));

                // Update the stored target position
                lastTargetPosition = target.transform.position;
            }
        }
    }
    private System.Collections.IEnumerator MoveFollower(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        transform.position = targetPosition; // Snap to final position
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand") && !followHand)
        {
            target=other.gameObject;
            if(objectID==0)
                SoundManagerEscape.instance.audioSource.clip = SoundManagerEscape.instance.openDrawer;
            if (objectID == 1)
                SoundManagerEscape.instance.audioSource.clip = SoundManagerEscape.instance.openDoor;
            SoundManagerEscape.instance.audioSource.Play();
            followHand = true;
            lastTargetPosition = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hand") && followHand)
        {
            followHand = false;

        }
    }
}
