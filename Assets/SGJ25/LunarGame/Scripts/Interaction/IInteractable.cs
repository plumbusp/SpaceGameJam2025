using UnityEngine;

namespace SGJ25.LunarGame.Interaction
{
    public interface IInteractable
    {
        void OnInteract(GameObject picker, InteractionType interactionType);
    }
}