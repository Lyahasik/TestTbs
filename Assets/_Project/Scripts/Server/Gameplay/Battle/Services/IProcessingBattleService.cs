using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.Services;
using _Project.Client.Gameplay.Character;

namespace _Project.Server.Gameplay.Battle.Services
{
    public interface IProcessingBattleService : IService
    {
        public void Initialize(CharacterStats playerStats, CharacterStats enemyStats);
        public void ProcessingStep(in StepDataMessage stepDataMessage);
    }
}