namespace ATGStateMachine
{
    /// <summary>
    /// For a more beautiful design.
    ///
    /// For Example:
    /// MoveBotState: BaseStategyStatement
    /// PlayerBotMovingBehaviour: IStrategyStateBehaviour
    /// EnemyBotMovingBehaviour: IStrategyStateBehaviour
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseStrategyStatement<T>: BaseStatement<T>
    {
        private readonly IStrategyStateBehaviour<T> _strategyState;

        public BaseStrategyStatement(T mainObject, 
            IStateSwitcher<T> stateSwitcher,IStrategyStateBehaviour<T> strategyState) 
            : base(mainObject, stateSwitcher)
        {
            _strategyState = strategyState;
            _strategyState.Init(mainObject);
        }

        public sealed override void Enter() => _strategyState.Enter();
        public sealed override void Execute() => _strategyState.Execute();
        public sealed override void Exit() => _strategyState.Exit();
    }
}