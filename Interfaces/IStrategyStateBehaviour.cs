namespace ATGStateMachine
{
    public interface IStrategyStateBehaviour<in T>: IStateable
    {
        void Init(T obj);
    }
}