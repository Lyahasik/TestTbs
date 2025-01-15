namespace _Project.Client.Core.BaseStateMachine.States
{
    public interface IState : IChangedState
    {
        public void Enter();
    }
}