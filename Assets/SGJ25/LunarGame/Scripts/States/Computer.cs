using System;
using SGJ25.LunarGame.Interaction;
using UnityEngine;

namespace SGJ25.LunarGame.States
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] private Camera m_computerCamera;

        [SerializeField] private TerminalController m_terminalController;

        [SerializeField] private Rover m_rover;

        private TerminalCommands _terminalCommands;

        public TerminalController TerminalController => m_terminalController;
        public Camera Camera => m_computerCamera;

        private void Start()
        {
            _terminalCommands = new TerminalCommands(m_terminalController, m_rover);
        }

        public void OnInteract(GameObject picker, InteractionType interactionType)
        {
            PlayerController playerController = picker.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                playerController.StateMachine.SetState(new ComputerState(this, playerController));
            }
        }
    }
}