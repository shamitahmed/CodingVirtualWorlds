using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnDelay;
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
        if(spawnDelay >= 1.5f )
        {
            GameObject go = Instantiate(ballPrefab, new Vector3(spawnPosX[Random.Range(0,spawnPosX.Length)], 1, spawnPosZ), Quaternion.identity);
            spawnCount++;
            spawnDelay = 0;
        }
    }
}
