using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnSwitcher : MonoBehaviour
{
    public static SpawnSwitcher instance;
    public SpawnManager spawnerL;
    public SpawnManager spawnerR;
    public GameObject lastL;
    public GameObject lastR;
    public bool canSwap;
    public float swapTimer;
    public float randSwapDistance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        randSwapDistance = Random.Range(3, 6);
    }
    private void Update()
    {
        swapTimer += Time.deltaTime;
        if(swapTimer >= randSwapDistance && !canSwap)
        {
            canSwap = true;
            SwapColors();
            swapTimer = 0;

        }
    }
    public void SwapColors()
    {
        if(lastL != null && lastR != null)
        {
            lastL.transform.DOMoveX(lastR.transform.position.x, 1f);
            lastR.transform.DOMoveX(lastL.transform.position.x, 1f);
        }
        randSwapDistance = Random.Range(3, 6);
        canSwap = false;
    }
}
