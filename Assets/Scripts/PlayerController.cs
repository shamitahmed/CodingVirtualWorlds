using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float yawAmount = 120f;
    private float yaw;
    public GameObject pp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float horInput = Input.GetAxis("Horizontal");
        transform.position += transform.right * horInput * moveSpeed * Time.deltaTime;
        if (transform.position.x < -4.5f)
            transform.position = new Vector3 (-4.5f,transform.position.y, transform.position.z);
        if (transform.position.x > 4.5f)
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);

        yaw += horInput * yawAmount * Time.deltaTime;
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horInput)) * -Mathf.Sign(horInput);

        transform.localRotation = Quaternion.Euler(0,0,roll);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blade"))
        {
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.CompareTag("danger"))
        {
            pp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("danger"))
        {
            pp.SetActive(false);
        }
    }
}
