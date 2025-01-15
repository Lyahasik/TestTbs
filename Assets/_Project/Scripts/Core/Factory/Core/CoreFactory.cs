using _Project.Core.StaticData.Services;
using _Project.Core.Update;
using _Project.Gameplay.Initialize;
using _Project.UI.Loading;

namespace _Project.Core.Factory.Core
{
    public class CoreFactory : Factory, ICoreFactory
    {
        private readonly IStaticDataService _staticDataService;

        public CoreFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public UpdateHandler CreateUpdateHandler() =>
            PrefabInstantiate(_staticDataService.Core.updateHandlerPrefab);

        public LoadingCurtain CreateLoadingCurtain()
        {
            var loadingCurtain = PrefabInstantiate(_staticDataService.Core.loadingCurtainPrefab);
            loadingCurtain.Construct(_staticDataService);
            
            return loadingCurtain;
        }

        public InitializerGameplay CreateInitializerGameplay()
        {
            var initializerGameplay = PrefabInstantiate(_staticDataService.Gameplay.initializerGameplayPrefab);
            initializerGameplay.Construct(_staticDataService);

            return initializerGameplay;
        }
    }
}