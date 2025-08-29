namespace SGJ25.LunarGame.States
{
    public class ComputerState : IPlayerState
    {
        private Computer _computer;
        
        public ComputerState(Computer Computer)
        {
            _computer = Computer;

        }
        public void Enter()
        {
            _computer.Camera.gameObject.SetActive(true);
            
        }

        public void Update()
        {
        }

        public void Exit()
        {
            _computer.Camera.gameObject.SetActive(false);

        }
    }
}