using System;
using UnityEngine;

namespace SGJ25.LunarGame.Interaction
{
    public enum InteractionType
    {
        Press,
        Hold
    }

    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private float m_interactionDistance = 3f;
        [SerializeField] private Camera m_playerCamera;

        private void TryInteract(InteractionType type)
        {
            int layerMask = ~LayerMask.GetMask("Player");

            Ray ray = new Ray(m_playerCamera.transform.position, m_playerCamera.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, m_interactionDistance, layerMask);

            Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

            foreach (var hit in hits)
            {
                var interactable = hit.transform.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnInteract(gameObject, InteractionType.Press);
                    return;
                }
            }
        }

        public void UpdateInteractionController()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
            {
                TryInteract(InteractionType.Press);
            }
        }
    }
}