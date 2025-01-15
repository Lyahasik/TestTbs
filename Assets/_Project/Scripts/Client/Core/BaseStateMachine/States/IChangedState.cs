namespace _Project.Client.Core.BaseStateMachine.States
{
    public interface IChangedState 
    {
        public void Update() {}
        public void Exit();
    }
}