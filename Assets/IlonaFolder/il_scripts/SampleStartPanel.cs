using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGJ25.LunarGame.Focusing;
using SGJ25.LunarGame.Interaction;

public class SampleStartPanel : MonoBehaviour, IFocusable, IInteractable
{
    public void OnFocusEnter(GameObject observer)
    {
        Debug.Log("OnFocusEnter sample panel");
    }

    public void OnFocusExit(GameObject observer)
    {
        Debug.Log("OnFocusExit sample panel");
    }

    public void OnInteract(GameObject picker, InteractionType interactionType)
    {
        Debug.Log("OnInteract in sample panel");
    }
}
