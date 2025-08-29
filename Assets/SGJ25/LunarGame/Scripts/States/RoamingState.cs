namespace SGJ25.LunarGame.States
{
    public class RoamingState : IPlayerState
    {
        private PlayerController m_playerController;
        
        public RoamingState(PlayerController playerController)
        {
            m_playerController = playerController;
        }
        public void Enter()
        {
            m_playerController.PlayerCamera.gameObject.SetActive(true);
        }

        public void Update()
        {
            m_playerController.MovementController.UpdateController();
            m_playerController.FocusController.UpdateFocusController();
            m_playerController.InteractionController.UpdateInteractionController();
        }

        public void Exit()
        {
            m_playerController.PlayerCamera.gameObject.SetActive(false);
        }
    }
}