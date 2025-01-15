using _Project.Client.Core.Network.Messages;
using _Project.Client.Gameplay.Battle.Services;
using _Project.Network;

namespace _Project.Client.Core.Network
{
    public class NetworkMessengerClient : NetworkMessenger
    {
        private ICreateBattleService _createBattleService;
        
        public void Initialize(ICreateBattleService createBattleService)
        {
            _createBattleService = createBattleService;
            
            _messageHandlers = new ();
            
            RegisterHandler<ParticipantsDataMessage>(OnGetParticipantsDataMessage);
        }

        private void OnGetParticipantsDataMessage(INetworkMessage message)
        {
            var participantsDataMessage = (ParticipantsDataMessage) message;
            
            _createBattleService.CreateBattle(participantsDataMessage.Player, participantsDataMessage.Enemy);
        }
    }
}