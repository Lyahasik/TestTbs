using System.Collections.Generic;
using _Project.Client.Core.Services;
using _Project.Client.Gameplay.Character;

namespace _Project.Client.Gameplay.Battle.Services
{
    public interface IProcessingStatsService : IService
    {
        public void UpdateStats(in ParticipantData playerData,
            List<SkillValueData> playerSkills,
            in ParticipantData enemyData,
            List<SkillValueData> enemySkills);
    }
}