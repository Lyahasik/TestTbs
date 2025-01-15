using _Project.Core.Services;

namespace _Project.Core.Scene.Services
{
    public interface ISceneProviderService : IService
    {
        public void LoadGameplayScene();
    }
}