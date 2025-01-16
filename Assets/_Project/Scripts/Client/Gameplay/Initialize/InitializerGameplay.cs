using _Project.Client.Core.Factory.Gameplay;
using _Project.Client.Core.Initialize;
using _Project.Client.Core.Services;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Battle.Services;
using _Project.Client.UI.Gameplay.Hud;
using _Project.Server.Gameplay.Battle.Services;
using UnityEngine;

namespace _Project.Client.Gameplay.Initialize
{
    public class InitializerGameplay : MonoBehaviour
    {
        private IStaticDataService _staticDataService;
        private CoreData _coreData;

        private ServicesContainer _gameplayServicesContainer;

        public void Construct(IStaticDataService staticDataService, CoreData coreData)
        {
            _staticDataService = staticDataService;
            _coreData = coreData;
        }

        public void Initialize()
        {
            RegisterServices();
            
            _gameplayServicesContainer.Single<ICreateBattleService>().RequestBattleData();
        }

        private void RegisterServices()
        {
            _gameplayServicesContainer = new ServicesContainer();

            RegisterGameplayFactory();
            RegisterProcessingRequestStepService();

            var hudView = _gameplayServicesContainer.Single<IGameplayFactory>().CreateHudView();
            hudView.Construct(
                _coreData.CoroutinesContainer,
                _gameplayServicesContainer.Single<IProcessingRequestStepService>());
            
            var gameplayBasis = _gameplayServicesContainer.Single<IGameplayFactory>().CreateGameplayBasis();

            RegisterCreateBattleService(gameplayBasis);
            RegisterProcessingBattleService();
            RegisterGenerateBattleService();
            RegisterProcessingStatsService(hudView);
            
            _coreData.NetworkMessengerClient.Initialize(
                _gameplayServicesContainer.Single<ICreateBattleService>(),
                _gameplayServicesContainer.Single<IProcessingStatsService>());
            
            _coreData.NetworkMessengerServer.Initialize(
                _gameplayServicesContainer.Single<IGenerateBattleService>(),
                _gameplayServicesContainer.Single<IProcessingBattleService>());
        }

        private void RegisterGameplayFactory()
        {
            var service = new GameplayFactory(_staticDataService);
            _gameplayServicesContainer.Register<IGameplayFactory>(service);
        }

        private void RegisterProcessingRequestStepService()
        {
            var service = new ProcessingRequestStepService(_coreData.NetworkMessengerServer);
            _gameplayServicesContainer.Register<IProcessingRequestStepService>(service);
        }

        private void RegisterCreateBattleService(GameplayBasis gameplayBasis)
        {
            var service = new CreateBattleService(
                _gameplayServicesContainer.Single<IGameplayFactory>(),
                _coreData.NetworkMessengerServer,
                gameplayBasis);
            _gameplayServicesContainer.Register<ICreateBattleService>(service);
        }

        private void RegisterProcessingBattleService()
        {
            var service = new ProcessingBattleService(_coreData.CoroutinesContainer, _coreData.NetworkMessengerClient);
            _gameplayServicesContainer.Register<IProcessingBattleService>(service);
        }

        private void RegisterGenerateBattleService()
        {
            var service = new GenerateBattleService(
                _staticDataService,
                _coreData.NetworkMessengerClient,
                _gameplayServicesContainer.Single<IProcessingBattleService>());
            _gameplayServicesContainer.Register<IGenerateBattleService>(service);
        }

        private void RegisterProcessingStatsService(HudView hudView)
        {
            var service = new ProcessingStatsService(hudView, _gameplayServicesContainer.Single<ICreateBattleService>());
            _gameplayServicesContainer.Register<IProcessingStatsService>(service);
        }
    }
}
