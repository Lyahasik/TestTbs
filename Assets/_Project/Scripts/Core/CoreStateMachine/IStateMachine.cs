using _Project.Core.BaseStateMachine.States;
using _Project.Core.Services;

namespace _Project.Core.CoreStateMachine
{
    public interface IStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TData>(TData data) where TState : class, IDataState<TData>;
    }
}