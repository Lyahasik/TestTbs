using _Project.Client.Core.Factory.Gameplay;
using _Project.Client.Core.Initialize;
using _Project.Client.Core.Services;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Battle.Services;
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

            var hudView = _gameplayServicesContainer.Single<IGameplayFactory>().CreateHudView();
            var gameplayBasis = _gameplayServicesContainer.Single<IGameplayFactory>().CreateGameplayBasis();

            RegisterCreateBattleService(gameplayBasis);
            RegisterGenerateBattleService();
        }

        private void RegisterGameplayFactory()
        {
            var service = new GameplayFactory(_staticDataService);
            _gameplayServicesContainer.Register<IGameplayFactory>(service);
        }

        private void RegisterCreateBattleService(GameplayBasis gameplayBasis)
        {
            var service = new CreateBattleService(
                _gameplayServicesContainer.Single<IGameplayFactory>(),
                _coreData.NetworkMessengerServer,
                gameplayBasis);
            _gameplayServicesContainer.Register<ICreateBattleService>(service);
            
            _coreData.NetworkMessengerClient.Initialize(service);
        }

        private void RegisterGenerateBattleService()
        {
            var service = new GenerateBattleService(_staticDataService, _coreData.NetworkMessengerClient);
            _gameplayServicesContainer.Register<IGenerateBattleService>(service);
            
            _coreData.NetworkMessengerServer.Initialize(service);
        }
    }
}
