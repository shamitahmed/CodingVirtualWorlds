using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float moveSpeed;
   

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;


    }

}
