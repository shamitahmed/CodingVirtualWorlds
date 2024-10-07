using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class GameManagerEscape : MonoBehaviour
{
    public static GameManagerEscape Instance;
    [Header("escape room")]
    public GameObject lampLight;
    public GameObject roof;
    public GameObject waterFallObject;
    public GameObject waterLevel;
    public bool win;
    public bool lose;
    public int candleCount;
    public GameObject window;
    public GameObject windowParts;
    public bool windowBroken;

    [Header("haptic")]
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    public float strength = 0.2f;
    public float duration = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        roof.SetActive(true);
        lampLight.SetActive(false);
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

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
