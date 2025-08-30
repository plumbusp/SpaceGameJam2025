using UnityEngine;

namespace SGJ25.LunarGame.States
{
    public class ComputerState : IPlayerState
    {
        private Computer m_computer;
        private PlayerController m_playerController;
        
        public ComputerState(Computer Computer, PlayerController playerController)
        {
            m_computer = Computer;
            m_playerController = playerController;

        }
        public void Enter()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            m_computer.Camera.gameObject.SetActive(true);
            m_computer.TerminalController.OnEnter();
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
            m_computer.Camera.gameObject.SetActive(false);
            m_computer.TerminalController.OnLeave();

        }
    }
}