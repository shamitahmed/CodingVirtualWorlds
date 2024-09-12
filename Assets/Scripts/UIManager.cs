using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtCombo;
    public TextMeshProUGUI txtMissed;
    public TextMeshProUGUI txtWrong;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;   
    }

}
