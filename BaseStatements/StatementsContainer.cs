using System;
using System.Collections.Generic;

namespace ATGStateMachine
{
    /// <summary>
    /// The base class of any object that can have several states
    /// _currentState contains the current state
    /// _allStates contains all possible states for a given object
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    public class StatementsContainer<T> : IStateSwitcher<T>
    {
        private BaseStatement<T> _currentState;
        private BaseStatement<T> _waitingState;

        private readonly Dictionary<Type, BaseStatement<T>> _allStates =
            new Dictionary<Type, BaseStatement<T>>();

        public StatementsContainer() {}

        public StatementsContainer(params BaseStatement<T>[] states)
        {
            _allStates = new Dictionary<Type, BaseStatement<T>>();

            foreach (var t in states)
                AddState(t);
        }

        // Call to add new state
        public void AddState(BaseStatement<T> newState)
        {
            Type type = newState.GetType();

            if (!_allStates.ContainsKey(type))
            {
                _allStates.Add(type, newState);
            }
            else throw new ArgumentException($"Added two identical states ({type}) !");
        }

        #region Init/Execute/Exit

        // Call to init first state
        public void OnInitState<TK>() where TK : BaseStatement<T>
        {
            var type = typeof(TK);

            _currentState = _allStates[type];

            if (_currentState != null)
                _currentState.Enter();

            else throw new NullReferenceException($"{type} state has not been added yet!");
        }

        // Call to Execute current state
        public void OnExecuteState()
        {
            _currentState?.Execute();
        }

        // Call to exit from current state and clear all states
        public void OnExitState()
        {
            _currentState?.Exit();

            _allStates.Clear();
            
            _currentState = null;
            _waitingState = null;
        }

        #endregion
        #region Continue/Pause

        // Call to continue work of state machine
        public void OnContinueState()
        {
            if (_currentState != null) return;

            _currentState = _waitingState;
            _waitingState = null;
        }

        // Call to stop work of state machine
        public void OnPauseState()
        {
            if (_currentState == null) return;

            _waitingState = _currentState;
            _currentState = null;
        }

        #endregion

        // switch state
        public void StateSwitcher<TK>() where TK : BaseStatement<T>
        {
            var type = typeof(TK);

            if (_allStates.ContainsKey(type))
            {
                //Exit from old current state
                _currentState?.Exit();

                //Setup new current state
                _currentState = _allStates[type];
                _currentState.Enter();
            }
            else throw new NullReferenceException($"{type} state has not been added yet!");
        }
    }
}