using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using DG.Tweening;
using Unity.VisualScripting;

public class UIManagerBowling : MonoBehaviour
{
    public static UIManagerBowling Instance;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtStrike;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public IEnumerator PerfectStrikeRoutine()
    {
        txtScore.gameObject.SetActive(false);
        txtStrike.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        txtScore.gameObject.SetActive(true);
        txtStrike.gameObject.SetActive(false);
    }
}
