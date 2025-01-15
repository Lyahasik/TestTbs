using _Project.Client.Core.Initialize;
using _Project.Client.Core.Services;
using _Project.Client.Core.Update;
using _Project.Client.Gameplay.Initialize;
using _Project.Client.UI.Loading;

namespace _Project.Client.Core.Factory.Core
{
    public interface ICoreFactory : IService
    {
        public UpdateHandler CreateUpdateHandler();
        public LoadingCurtain CreateLoadingCurtain();
        public InitializerGameplay CreateInitializerGameplay(CoreData coreData);
    }
}