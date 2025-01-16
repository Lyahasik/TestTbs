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
            
            RegisterHandler<ParticipantsDataMessage>(OnGetParticipantsDataMessage);
            RegisterHandler<UpdateStatsDataMessage>(OnGetUpdateStatsDataMessage);
        }

        private void OnGetParticipantsDataMessage(INetworkMessage message)
        {
            var participantsDataMessage = (ParticipantsDataMessage) message;
            
            _createBattleService.CreateBattle(participantsDataMessage.Player, participantsDataMessage.Enemy);
        }

        private void OnGetUpdateStatsDataMessage(INetworkMessage message)
        {
            var updateStatsDataMessage = (UpdateStatsDataMessage) message;
            
            _processingStatsService.UpdateStats(updateStatsDataMessage.Player, updateStatsDataMessage.Enemy);
        }
    }
}