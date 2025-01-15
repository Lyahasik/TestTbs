namespace _Project.Client.Core.BaseStateMachine.States
{
    public interface IDataState<TData> : IChangedState
    {
        public void Enter(TData data);
    }
}