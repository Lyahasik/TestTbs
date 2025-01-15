using _Project.Client.Core.Services;

namespace _Project.Client.Core.Scene.Services
{
    public interface ISceneProviderService : IService
    {
        public void LoadGameplayScene();
    }
}