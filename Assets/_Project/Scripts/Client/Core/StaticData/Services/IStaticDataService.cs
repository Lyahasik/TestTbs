using _Project.Client.Core.Services;

using ClientGameplayStaticData = _Project.Client.Gameplay.StaticData.GameplayStaticData;
using ServerGameplayStaticData = _Project.Server.Gameplay.StaticData.GameplayStaticData;

namespace _Project.Client.Core.StaticData.Services
{
    public interface IStaticDataService : IService
    {
        public CoreStaticData Core { get; }
        public ClientGameplayStaticData ClientGameplay { get; }
        public ServerGameplayStaticData ServerGameplay { get; }

        public void Load();
    }
}