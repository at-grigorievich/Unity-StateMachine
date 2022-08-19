namespace ATGStateMachine
{
    public interface IStateable
    {
        public void Enter(); // Enter the state callback
        public void Exit() { } // Exit the state callback
        public void Execute() { } // Stay the state callback
    }
}