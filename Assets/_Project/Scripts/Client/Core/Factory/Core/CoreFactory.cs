using _Project.Client.Core.Initialize;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Core.Update;
using _Project.Client.Gameplay.Initialize;
using _Project.Client.UI.Loading;

namespace _Project.Client.Core.Factory.Core
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

        public InitializerGameplay CreateInitializerGameplay(CoreData coreData)
        {
            var initializerGameplay = PrefabInstantiate(_staticDataService.ClientGameplay.initializerGameplayPrefab);
            initializerGameplay.Construct(_staticDataService, coreData);

            return initializerGameplay;
        }
    }
}