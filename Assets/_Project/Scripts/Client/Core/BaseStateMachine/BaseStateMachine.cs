using System;
using System.Collections.Generic;
using _Project.Client.Core.BaseStateMachine.States;
using _Project.Client.Core.CoreStateMachine;
using _Project.Client.Core.Update;

namespace _Project.Client.Core.BaseStateMachine
{
    public abstract class BaseStateMachine : IStateMachine, IUpdating
    {
        protected Dictionary<Type, IChangedState> _states;
        protected IChangedState _activeState;

        public void Enter<TState>() where TState : class, IState
        {
            ChangeState<TState>();
            (_activeState as TState).Enter();
        }

        public void Enter<TState, TData>(TData data) where TState : class, IDataState<TData>
        {
            ChangeState<TState>();
            (_activeState as TState).Enter(data);
        }
        
        public virtual void Update() {}

        protected void ChangeState<TState>() where TState : class, IChangedState
        {
            _activeState?.Exit();
      
            TState state = GetState<TState>();
            _activeState = state;
        }

        private TState GetState<TState>() where TState : class, IChangedState => 
            _states[typeof(TState)] as TState;
    }
}