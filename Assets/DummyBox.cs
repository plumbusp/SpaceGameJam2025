using System.Collections;
using System.Collections.Generic;
using SGJ25.LunarGame.Focusing;
using SGJ25.LunarGame.Interaction;
using UnityEngine;

public class DummyBox : MonoBehaviour, IInteractable, IFocusable
{
    public void OnInteract(GameObject picker, InteractionType interactionType)
    {
       GetComponent<Rigidbody>().AddForce(picker.transform.forward * 10,ForceMode.Impulse);
    }

    public void OnFocusEnter(GameObject observer)
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnFocusExit(GameObject observer)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
