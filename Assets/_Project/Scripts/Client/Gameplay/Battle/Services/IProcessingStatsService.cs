using _Project.Client.Core.Services;

namespace _Project.Client.Gameplay.Battle.Services
{
    public interface IProcessingStatsService : IService
    {
        public void UpdateStats(in ParticipantData playerData, in ParticipantData enemyData);
    }
}