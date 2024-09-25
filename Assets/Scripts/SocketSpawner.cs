using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSpawner : MonoBehaviour
{
    private XRSocketInteractor socket;
    public XRBaseInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }
    public void SpawnBall()
    {
        var instance = Instantiate(interactable);
        socket.interactionManager.ForceSelect(socket, instance);
    }

}
