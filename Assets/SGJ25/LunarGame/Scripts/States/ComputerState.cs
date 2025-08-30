using UnityEngine;

namespace SGJ25.LunarGame.States
{
    public class ComputerState : IPlayerState
    {
        private Computer _computer;
        private PlayerController m_playerController;
        
        public ComputerState(Computer Computer, PlayerController playerController)
        {
            _computer = Computer;
            m_playerController = playerController;

        }
        public void Enter()
        {
            _computer.Camera.gameObject.SetActive(true);
            
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_playerController.StateMachine.SetState(new RoamingState(m_playerController));
            }
        }

        public void Exit()
        {
            _computer.Camera.gameObject.SetActive(false);

        }
    }
}