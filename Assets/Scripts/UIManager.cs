using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtCombo;
    public TextMeshProUGUI txtMissed;
    public TextMeshProUGUI txtWrong;
    public bool isMissedShowing;
    public float missedShowTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;   
    }
    private void Update()
    {
        //HardMissedOff();
    }
    void HardMissedOff()
    {
        if (isMissedShowing)
        {
            missedShowTime += Time.deltaTime;
            if (missedShowTime >= 0.5f)
            {
                txtMissed.gameObject.SetActive(false);
                missedShowTime = 0f;
            }
        }
    }
    public IEnumerator MissedUIRoutine()
    {
        if(!isMissedShowing)
        {
            txtMissed.gameObject.SetActive(true);
            isMissedShowing = true;
            yield return new WaitForSeconds(0.2f);
            txtMissed.gameObject.SetActive(false);
            isMissedShowing = false;
        }
    }
}
