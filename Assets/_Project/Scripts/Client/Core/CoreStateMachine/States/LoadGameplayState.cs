using _Project.Client.Core.BaseStateMachine.States;
using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Scene.Services;
using _Project.Client.UI.Loading;
using UnityEngine;

namespace _Project.Client.Core.CoreStateMachine.States
{
    public class LoadGameplayState : IState
    {
        private readonly ISceneProviderService sceneProviderService;
        private readonly CoroutinesContainer coroutinesContainer;
        private readonly LoadingCurtain curtain;

        public LoadGameplayState(ISceneProviderService sceneProviderService,
            CoroutinesContainer coroutinesContainer,
            LoadingCurtain curtain)
        {
            this.sceneProviderService = sceneProviderService;
            this.coroutinesContainer = coroutinesContainer;
            this.curtain = curtain;
        }

        public void Enter()
        {
            Debug.Log($"Start state { GetType().Name }");
            
            curtain.Show();
            sceneProviderService.LoadGameplayScene();
        }

        public void Exit()
        {
            curtain.Hide(coroutinesContainer);
        }
    }
}