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
        
        public void UpdateStats(in ParticipantData playerData, in ParticipantData enemyData)
        {
            _hudView.ShowStep();
            
            _createBattleService.Player.SetStats(playerData);
            _createBattleService.Enemy.SetStats(enemyData);
        }
    }
}