namespace SGJ25.LunarGame.States
{
    public class PlayerStaStateMachine
    {
        private IPlayerState _currentState;

        public void SetState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}