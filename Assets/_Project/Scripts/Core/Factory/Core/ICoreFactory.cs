using _Project.Core.Services;
using _Project.Core.Update;
using _Project.Gameplay.Initialize;
using _Project.UI.Loading;

namespace _Project.Core.Factory.Core
{
    public interface ICoreFactory : IService
    {
        public UpdateHandler CreateUpdateHandler();
        public LoadingCurtain CreateLoadingCurtain();
        public InitializerGameplay CreateInitializerGameplay();
    }
}