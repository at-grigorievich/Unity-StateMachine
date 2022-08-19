namespace ATGStateMachine
{
    /// <summary>
    /// Base class of any object state
    /// This type can manipulate data of type T
    /// And also change the state based on the conditions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseStatement<T>: IStateable
    {
        protected readonly T MainObject; // Manipulate object
        protected readonly IStateSwitcher<T> StateSwitcher; // Switch state
        
        protected BaseStatement(T mainObject, IStateSwitcher<T> stateSwitcher)
        {
            MainObject = mainObject;
            StateSwitcher = stateSwitcher;
        }

        public abstract void Enter(); // Enter the state callback
        public virtual void Exit() { } // Exit the state callback
        public virtual void Execute() { } // Stay the state callback
        
    }
}
