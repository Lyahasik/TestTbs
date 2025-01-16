using System.Collections.Generic;
using _Project.Client.Gameplay.Character;
using _Project.Client.UI.Gameplay.Hud;

namespace _Project.Client.Gameplay.Battle.Services
{
    public class ProcessingStatsService : IProcessingStatsService
    {
        private readonly HudView _hudView;
        private readonly ICreateBattleService _createBattleService;

        public ProcessingStatsService(HudView hudView,
            ICreateBattleService createBattleService)
        {
            _hudView = hudView;
            _createBattleService = createBattleService;
        }
        
        public void UpdateStats(in ParticipantData playerData,
            List<SkillValueData> playerSkills,
            in ParticipantData enemyData,
            List<SkillValueData> enemySkills)
        {
            if (playerData.Health == 0
                || enemyData.Health == 0)
            {
                _hudView.GameEnd();
                return;
            }
            
            _hudView.ShowStep(playerSkills);
            
            _createBattleService.Player.SetStats(playerData, playerSkills);
            _createBattleService.Enemy.SetStats(enemyData, enemySkills);
        }
    }
}