namespace _Project.Core.BaseStateMachine.States
{
    public interface IChangedState 
    {
        public void Update() {}
        public void Exit();
    }
}