using UnityEngine;

namespace SGJ25.LunarGame.Focusing
{
    public class FocusController : MonoBehaviour
    {
        [SerializeField] private float m_focusDistance = 3f;
        [SerializeField] private Camera m_playerCamera;
        private IFocusable _currentFocusTarget;

        public void UpdateFocusController()
        {
            var layerMask = ~LayerMask.GetMask("Player");
            var ray = new Ray(m_playerCamera.transform.position, m_playerCamera.transform.forward);
            if (Physics.Raycast(ray, out var hit, m_focusDistance, layerMask))
            {
                var focusable = hit.transform.GetComponent<IFocusable>();
                if (focusable != null)
                {
                    if (focusable != _currentFocusTarget)
                    {
                        _currentFocusTarget?.OnFocusExit(gameObject);
                        _currentFocusTarget = focusable;
                        _currentFocusTarget.OnFocusEnter(gameObject);
                    }

                    return;
                }
            }

            if (_currentFocusTarget != null)
            {
                _currentFocusTarget.OnFocusExit(gameObject);
                _currentFocusTarget = null;
            }
        }
    }
}