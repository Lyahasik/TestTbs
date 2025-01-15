using _Project.Core.BaseStateMachine.States;
using UnityEngine;

namespace _Project.Core.CoreStateMachine.States
{
    public class GameplayState : IState
    {
        public GameplayState()
        {
        }
        
        public void Enter()
        {
            Debug.Log($"Start state {GetType().Name}");
        }

        public void Exit() {}
    }
}