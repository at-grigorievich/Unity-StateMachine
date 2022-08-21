using UnityEngine;

namespace ATGStateMachine
{
    /// <summary>
    /// StatementContainer wrapper for MonoBehaviour objects
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    public abstract class StatementBehaviour<T> : MonoBehaviour, IStateSwitcher<T>
    {
        protected StatementsContainer<T> _statementsContainer;
        
        protected virtual void Update() => _statementsContainer?.OnExecuteState();
       
        protected virtual void OnEnable() => _statementsContainer?.OnContinueState();
        protected virtual void OnDisable() => _statementsContainer?.OnPauseState();
       
        protected virtual void OnDestroy() => _statementsContainer?.OnExitState();

        
        public void StateSwitcher<TK>() where TK : BaseStatement<T> =>
            _statementsContainer?.StateSwitcher<TK>();
    }
}