using SGJ25.LunarGame.Interaction;
using UnityEngine;

namespace SGJ25.LunarGame.States
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] private Camera m_computerCamera;

        public Camera Camera => m_computerCamera;

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