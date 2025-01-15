using _Project.Core.CoreStateMachine;
using _Project.Core.CoreStateMachine.States;
using _Project.Core.Factory.Core;
using _Project.Core.Scene.Services;
using _Project.Core.Services;
using _Project.Core.StaticData.Services;
using _Project.Core.Update;
using _Project.UI.Loading;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Core.Initialize
{
    public class InitializerCore : MonoBehaviour
    {
        private ServicesContainer _coreServicesContainer;

        private void Start()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            _coreServicesContainer = new ServicesContainer();
            var gameStateMachine = new CoreStateMachine.CoreStateMachine();
            
            RegisterStaticDataService();
            RegisterCoreFactory();
            
            UpdateHandler updateHandler = _coreServicesContainer.Single<ICoreFactory>().CreateUpdateHandler();
            LoadingCurtain curtain = _coreServicesContainer.Single<ICoreFactory>().CreateLoadingCurtain();
            CoreData coreData = GameDataCreate(curtain);
            
            RegisterSceneProviderService(gameStateMachine, updateHandler);

            gameStateMachine.Initialize(
                _coreServicesContainer.Single<ISceneProviderService>(),
                coreData.CoroutinesContainer,
                coreData.Curtain);
            _coreServicesContainer.Register<IStateMachine>(gameStateMachine);
            
            gameStateMachine.Enter<LoadGameplayState>();
            
            DontDestroyOnLoad(coreData);
        }

        private void RegisterStaticDataService()
        {
            var service = new StaticDataService();
            service.Load();
            _coreServicesContainer.Register<IStaticDataService>(service);
        }

        private void RegisterCoreFactory()
        {
            var service = new CoreFactory(_coreServicesContainer.Single<IStaticDataService>());
            _coreServicesContainer.Register<ICoreFactory>(service);
        }

        private CoreData GameDataCreate(LoadingCurtain curtain)
        {
            CoreData coreData = new GameObject().AddComponent<CoreData>();
            coreData.name = nameof(CoreData);
            
            Coroutines.CoroutinesContainer coroutinesContainer = coreData.AddComponent<Coroutines.CoroutinesContainer>();
            coreData.Construct(curtain, coroutinesContainer);
            
            return coreData;
        }

        private void RegisterSceneProviderService(CoreStateMachine.CoreStateMachine coreStateMachine,
            UpdateHandler updateHandler)
        {
            var service = new SceneProviderService(
                coreStateMachine,
                _coreServicesContainer.Single<IStaticDataService>(),
                _coreServicesContainer.Single<ICoreFactory>(),
                updateHandler);
            _coreServicesContainer.Register<ISceneProviderService>(service);
        }
    }
}
