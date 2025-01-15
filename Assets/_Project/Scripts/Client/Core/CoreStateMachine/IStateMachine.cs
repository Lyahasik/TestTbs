using _Project.Client.Core.BaseStateMachine.States;
using _Project.Client.Core.Services;

namespace _Project.Client.Core.CoreStateMachine
{
    public interface IStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TData>(TData data) where TState : class, IDataState<TData>;
    }
}