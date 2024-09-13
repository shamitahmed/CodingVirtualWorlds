using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefab;
    public float timer;
    public float spawnInterval= (60/105);
    public int spawnCount;
    public float[] spawnPosX;
    public float spawnPosZ;
    public float initDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (timer >= spawnInterval)
        {
            GameObject go = Instantiate(ballPrefab[Random.Range(0, ballPrefab.Length)], new Vector3(spawnPosX[Random.Range(0, spawnPosX.Length)], 1, spawnPosZ), Quaternion.identity);
            go.transform.DOScale(go.transform.localScale * 2f, 0.2f).SetLoops(2, LoopType.Yoyo);
            spawnCount++;
            timer -= spawnInterval;
        }
        timer += Time.deltaTime;
    }
}
