namespace _Project.Core.BaseStateMachine.States
{
    public interface IDataState<TData> : IChangedState
    {
        public void Enter(TData data);
    }
}