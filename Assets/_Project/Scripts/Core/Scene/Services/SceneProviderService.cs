using System;
using _Project.Constants;
using _Project.Core.CoreStateMachine;
using _Project.Core.CoreStateMachine.States;
using _Project.Core.Factory.Core;
using _Project.Core.StaticData.Services;
using _Project.Core.Update;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Core.Scene.Services
{
    public class SceneProviderService : ISceneProviderService
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly ICoreFactory _coreFactory;
        private readonly UpdateHandler _updateHandler;

        private string _nameNewActiveScene;

        public SceneProviderService(IStateMachine stateMachine,
            IStaticDataService staticDataService,
            ICoreFactory coreFactory,
            UpdateHandler updateHandler)
        {
            _stateMachine = stateMachine;
            _updateHandler = updateHandler;
            _coreFactory = coreFactory;
            _staticDataService = staticDataService;
            
            Debug.Log($"[{ GetType() }] initialize");
        }

        public void LoadGameplayScene()
        {
            Debug.Log("Current active scene : " + SceneManager.GetActiveScene().name);
            
            LoadScene($"{ ConstantValues.SCENE_NAME_GAMEPLAY }", PrepareGameplay);
        }

        private void LoadScene(string sceneName, Action<AsyncOperation> prepareScene)
        {
            _nameNewActiveScene = sceneName;
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += prepareScene;
        }

        private void PrepareGameplay(AsyncOperation obj)
        {
            string oldSceneName = SceneManager.GetActiveScene().name;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_nameNewActiveScene));
            SceneManager.UnloadSceneAsync(oldSceneName);
            Debug.Log("New active scene : " + SceneManager.GetActiveScene().name);

            var initializerGameplay = _coreFactory.CreateInitializerGameplay();
            initializerGameplay.Initialize();
            
            Debug.Log("Gameplay scene loaded.");
            _stateMachine.Enter<GameplayState>();
        }
    }
}