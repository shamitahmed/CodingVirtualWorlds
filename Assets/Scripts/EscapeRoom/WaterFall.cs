using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WaterFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            SoundManagerEscape.instance.waterfall.SetActive(true);
            GameManagerEscape.Instance.waterLevel.SetActive(true);
            GameManagerEscape.Instance.waterFallObject.SetActive(true);
            GameManagerEscape.Instance.waterLevel.transform.DOMoveY(1, 250);
        }
    }
}
