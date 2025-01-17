using System.Collections.Generic;
using _Project.Client.Core.Services;
using _Project.Client.Gameplay.Character;

namespace _Project.Client.Gameplay.Battle.Services
{
    public interface ICreateBattleService : IService
    {
        public CharacterView Player { get; }
        public CharacterView Enemy { get; }
        public void RequestBattleData();
        public void CreateBattle(in ParticipantData playerData,
            List<SkillValueData> playerSkills,
            in ParticipantData enemyData,
            List<SkillValueData> enemySkills);
    }
}