using System;
using SGJ25.LunarGame.Focusing;
using SGJ25.LunarGame.Interaction;
using SGJ25.LunarGame.Movement;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private FirstPersonMovementController _movementController;
    [SerializeField] private FocusController m_focus;
    [SerializeField] private InteractionController m_interaction;


    private void Update()
    {
        _movementController.UpdateController();
        m_focus.UpdateFocusController();
        m_interaction.UpdateInteractionController();
    }
}