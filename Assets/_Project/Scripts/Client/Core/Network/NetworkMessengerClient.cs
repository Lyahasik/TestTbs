using _Project.Client.Core.Network.Messages;
using _Project.Client.Gameplay.Battle.Services;
using _Project.Network;

namespace _Project.Client.Core.Network
{
    public class NetworkMessengerClient : NetworkMessenger
    {
        private ICreateBattleService _createBattleService;
        private IProcessingStatsService _processingStatsService;
        
        public void Initialize(ICreateBattleService createBattleService, IProcessingStatsService processingStatsService)
        {
            _createBattleService = createBattleService;
            _processingStatsService = processingStatsService;
            
            _messageHandlers = new ();
            
            RegisterHandler<StartDataMessage>(OnGetStartDataMessage);
            RegisterHandler<UpdateStatsDataMessage>(OnGetUpdateStatsDataMessage);
        }

        private void OnGetStartDataMessage(INetworkMessage message)
        {
            var startDataMessage = (StartDataMessage) message;
            
            _createBattleService.CreateBattle(
                startDataMessage.ParticipantPlayer,
                startDataMessage.SkillsPlayer,
                    startDataMessage.ParticipantEnemy,
                startDataMessage.SkillsEnemy);
        }

        private void OnGetUpdateStatsDataMessage(INetworkMessage message)
        {
            var updateStatsDataMessage = (UpdateStatsDataMessage) message;
            
            _processingStatsService.UpdateStats(
                updateStatsDataMessage.ParticipantPlayer,
                updateStatsDataMessage.SkillsPlayer,
                updateStatsDataMessage.ParticipantEnemy,
                updateStatsDataMessage.SkillsEnemy);
        }
    }
}