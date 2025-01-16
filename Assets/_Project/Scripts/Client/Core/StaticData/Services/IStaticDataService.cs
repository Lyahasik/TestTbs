using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.Services;
using _Project.Client.Gameplay.Character;
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

        public SkillData GetPlayerSkillData(SkillType skillType);
        public SkillData GetEnemySkillData(SkillType skillType);
    }
}