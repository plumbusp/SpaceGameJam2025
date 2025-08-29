using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGJ25.LunarGame.Interaction;

public class StaticPlayerController : MonoBehaviour
{
    [SerializeField] private StaticPlayerRotation _staticPlayerRotation;
    [SerializeField] private InteractionController _interactionController;

    private void Start()
    {
        Camera cam = Camera.main;
        cam.ResetProjectionMatrix();
    }
    private void Update()
    {
        _staticPlayerRotation.UpdateController();
        _interactionController.UpdateInteractionController();
    }
}
