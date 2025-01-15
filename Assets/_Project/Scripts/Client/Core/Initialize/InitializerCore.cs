using _Project.Client.Core.CoreStateMachine;
using _Project.Client.Core.CoreStateMachine.States;
using _Project.Client.Core.Factory.Core;
using _Project.Client.Core.Network;
using _Project.Client.Core.Scene.Services;
using _Project.Client.Core.Services;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Core.Update;
using _Project.Client.UI.Loading;
using _Project.Server.Core.Network;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Client.Core.Initialize
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
            NetworkMessengerServer networkMessengerServer = new NetworkMessengerServer();
            NetworkMessengerClient networkMessengerClient = new NetworkMessengerClient();
            
            CoreData coreData = GameDataCreate(curtain, networkMessengerServer, networkMessengerClient);
            
            RegisterSceneProviderService(gameStateMachine, coreData, updateHandler);

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

        private CoreData GameDataCreate(LoadingCurtain curtain,
            NetworkMessengerServer networkMessengerServer,
            NetworkMessengerClient networkMessengerClient)
        {
            CoreData coreData = new GameObject().AddComponent<CoreData>();
            coreData.name = nameof(CoreData);
            
            Coroutines.CoroutinesContainer coroutinesContainer = coreData.AddComponent<Coroutines.CoroutinesContainer>();
            coreData.Construct(curtain, coroutinesContainer, networkMessengerServer, networkMessengerClient);
            
            return coreData;
        }

        private void RegisterSceneProviderService(CoreStateMachine.CoreStateMachine coreStateMachine,
            CoreData coreData,
            UpdateHandler updateHandler)
        {
            var service = new SceneProviderService(
                coreStateMachine,
                _coreServicesContainer.Single<IStaticDataService>(),
                _coreServicesContainer.Single<ICoreFactory>(),
                coreData,
                updateHandler);
            _coreServicesContainer.Register<ISceneProviderService>(service);
        }
    }
}
