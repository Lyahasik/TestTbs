using System;
using _Project.Client.Core.CoreStateMachine;
using _Project.Client.Core.CoreStateMachine.States;
using _Project.Client.Core.Factory.Core;
using _Project.Client.Core.Initialize;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Core.Update;
using _Project.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Client.Core.Scene.Services
{
    public class SceneProviderService : ISceneProviderService
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly ICoreFactory _coreFactory;
        private readonly CoreData _coreData;
        private readonly UpdateHandler _updateHandler;

        private string _nameNewActiveScene;

        public SceneProviderService(IStateMachine stateMachine,
            IStaticDataService staticDataService,
            ICoreFactory coreFactory,
            CoreData coreData,
            UpdateHandler updateHandler)
        {
            _stateMachine = stateMachine;
            _updateHandler = updateHandler;
            _coreFactory = coreFactory;
            _coreData = coreData;
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

            var initializerGameplay = _coreFactory.CreateInitializerGameplay(_coreData);
            initializerGameplay.Initialize();
            
            Debug.Log("Gameplay scene loaded.");
            _stateMachine.Enter<GameplayState>();
        }
    }
}