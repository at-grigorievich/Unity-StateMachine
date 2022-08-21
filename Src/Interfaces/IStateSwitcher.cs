namespace ATGStateMachine 
{
    /// <summary>
    /// State switching interface
    /// </summary>
    public interface IStateSwitcher<T>
    {
        void StateSwitcher<TK>() where TK: BaseStatement<T>;
    }
}
