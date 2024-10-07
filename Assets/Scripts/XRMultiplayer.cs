using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

public class XRMultiplayer : MonoBehaviour
{
  public void RequestOwnership(SelectEnterEventArgs args)
    {
        var xrBaseInteractable = args.interactable;
        var realtimeView = xrBaseInteractable.GetComponent<RealtimeView>();
        var realtimeTransform = xrBaseInteractable.GetComponent<RealtimeTransform>();

        if(realtimeView != null)
        {
            realtimeView.RequestOwnership();
        }
        else
        {
            Debug.LogWarning("No realtimeView found");
        }

        if(realtimeTransform != null)
        {
            realtimeTransform.RequestOwnership();
        }
        {
            Debug.LogWarning("No realtimeTransform found");
        }
    }
}
