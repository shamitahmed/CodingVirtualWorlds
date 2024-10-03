using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManagerEscape.instance.winPanel.SetActive(true);
            GameManagerEscape.Instance.win = true;
            StartCoroutine(GameManagerEscape.Instance.Restart());
        }
    }
}
