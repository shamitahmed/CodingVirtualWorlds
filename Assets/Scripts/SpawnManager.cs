using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefab;
    public float spawnDelay;
    public float spawnInterval=1f;
    public int spawnCount;
    public float[] spawnPosX;
    public float spawnPosZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        spawnDelay += Time.deltaTime;
        if(spawnDelay >= spawnInterval )
        {
            GameObject go = Instantiate(ballPrefab[Random.Range(0, ballPrefab.Length)], new Vector3(spawnPosX[Random.Range(0,spawnPosX.Length)], 1, spawnPosZ), Quaternion.identity);
            //SoundManager.instance.audioSource.clip = SoundManager.instance.spawnBall;
            //SoundManager.instance.audioSource.Play();
            spawnCount++;
            spawnDelay = 0;
        }
    }
}
