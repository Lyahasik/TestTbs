using System;
using System.Collections.Generic;
using _Project.Core.BaseStateMachine.States;
using _Project.Core.CoreStateMachine.States;
using _Project.Core.Coroutines;
using _Project.Core.Scene.Services;
using _Project.UI.Loading;

namespace _Project.Core.CoreStateMachine
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