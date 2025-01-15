namespace _Project.Core.BaseStateMachine.States
{
    public interface IState : IChangedState
    {
        public void Enter();
    }
}