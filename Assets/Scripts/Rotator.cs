using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Rotation speed & axis
    public Vector3 rotation;

    // Rotation space
    public Space space = Space.Self;

    void Update()
    {
        this.transform.Rotate(rotation * Time.deltaTime, space);
    }
}
