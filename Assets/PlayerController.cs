using System;
using SGJ25.LunarGame.Focusing;
using SGJ25.LunarGame.Interaction;
using SGJ25.LunarGame.Movement;
using SGJ25.LunarGame.States;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStaStateMachine _playerStaStateMachine;

    [SerializeField] Camera m_playerCamera;
    [SerializeField] private FirstPersonMovementController _movementController;
    [SerializeField] private FocusController m_focus;
    [SerializeField] private InteractionController m_interaction;
    public FirstPersonMovementController MovementController => _movementController;
    public FocusController FocusController => m_focus;
    public InteractionController InteractionController => m_interaction;

    public Camera PlayerCamera => m_playerCamera;
    public PlayerStaStateMachine StateMachine => _playerStaStateMachine;

    private void Start()
    {
        _playerStaStateMachine = new PlayerStaStateMachine();
        _playerStaStateMachine.SetState(new RoamingState(this));
    }

    private void Update()
    {
        _playerStaStateMachine.Update();
    }
}