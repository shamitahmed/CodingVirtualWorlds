using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float speed;
    private bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveMouse();
    }
    void MoveMouse()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
    }
    void TurnMouse()
    {
        if (isFlipped)
        {
            // Reset to original rotation
            transform.rotation = Quaternion.identity;
        }
        else
        {
            // Flip by 180 degrees around the Y axis
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Toggle the flipping state
        isFlipped = !isFlipped;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            TurnMouse();
        }
    }
}
