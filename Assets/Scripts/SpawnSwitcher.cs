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
        randSwapDistance = Random.Range(3,7);
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
        if(lastL != null && lastR != null && !spawnerL.skipped && !spawnerR.skipped)
        {
            lastL.transform.DOMoveX(lastR.transform.position.x, 1f);
            lastR.transform.DOMoveX(lastL.transform.position.x, 1f);
        }


        //handle situation when spawner skips a spawn
        //1. detect 2. move only 1 instead of both

        if (spawnerL.skipped)
        {
            lastR.transform.DOMoveX(-1.65f, 1f);
        }
        else if (spawnerR.skipped)
        {
            lastL.transform.DOMoveX(2f, 1f);
        }
        else if(spawnerL.skipped && spawnerR.skipped)
        {
            //do nothing, skip!
        }

        randSwapDistance = Random.Range(3,7);
        canSwap = false;
    }
}
