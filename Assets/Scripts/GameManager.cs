using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform[] pinSpawnPos;
    public GameObject pinPrefab;
    public GameObject[] pinObjectAlleys;
    public Material pinDedMat;
    [Header("haptic")]
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    public float strength = 0.2f;
    public float duration = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    public void SpawnPins(int alleyID)
    {
        LeftControllerVibration(strength * 2, duration);
        RightControllerVibration(strength * 2, duration);

        GameObject go = Instantiate(pinPrefab, pinSpawnPos[alleyID].transform.position, pinPrefab.transform.rotation);
        pinObjectAlleys[alleyID] = go;

        //assign alley ID to spawned pins
        for (int i = 0; i < 10; i++)
        {
            go.transform.GetChild(i).GetChild(0).GetComponent<PinCollision>().alleyID = alleyID;
        }

        SoundManager.instance.audioSource.clip = SoundManager.instance.perfectStrike;
        SoundManager.instance.audioSource.Play();
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
