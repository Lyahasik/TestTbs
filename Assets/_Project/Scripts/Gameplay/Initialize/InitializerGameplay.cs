using _Project.Core.Factory.Gameplay;
using _Project.Core.Services;
using _Project.Core.StaticData.Services;
using UnityEngine;

namespace _Project.Gameplay.Initialize
{
    public class InitializerGameplay : MonoBehaviour
    {
        private IStaticDataService _staticDataService;
        
        private ServicesContainer _gameplayServicesContainer;

        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            _gameplayServicesContainer = new ServicesContainer();

            RegisterGameplayFactory();

            var hudView = _gameplayServicesContainer.Single<IGameplayFactory>().CreateHudView();
        }

        private void RegisterGameplayFactory()
        {
            var service = new GameplayFactory(_staticDataService);
            _gameplayServicesContainer.Register<IGameplayFactory>(service);
        }
    }
}
