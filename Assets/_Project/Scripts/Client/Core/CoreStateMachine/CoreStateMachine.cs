using System;
using System.Collections.Generic;
using _Project.Client.Core.BaseStateMachine.States;
using _Project.Client.Core.CoreStateMachine.States;
using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Scene.Services;
using _Project.Client.UI.Loading;

namespace _Project.Client.Core.CoreStateMachine
{
    public class CoreStateMachine : BaseStateMachine.BaseStateMachine
    {
        public void Initialize(ISceneProviderService sceneProviderService,
            CoroutinesContainer coroutinesContainer,
            LoadingCurtain curtain)
        {
            _states = new Dictionary<Type, IChangedState>
            {
                [typeof(LoadGameplayState)] = new LoadGameplayState(sceneProviderService, coroutinesContainer, curtain),
                [typeof(GameplayState)] = new GameplayState()
            };
        }
    }
}