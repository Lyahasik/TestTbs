using _Project.Network;
using _Project.Server.Core.Network.ServerMessages;
using _Project.Server.Gameplay.Battle.Services;

namespace _Project.Server.Core.Network
{
    public class NetworkMessengerServer : NetworkMessenger
    {
        private IGenerateBattleService _generateBattleService;
        
        public void Initialize(IGenerateBattleService generateBattleService)
        {
            _generateBattleService = generateBattleService;
            
            _messageHandlers = new ();
            
            RegisterHandler<GenerateBattleMessage>(OnReceiveStepMessage);
        }

        private void OnReceiveStepMessage(INetworkMessage message)
        {
            var generateBattleMessage = (GenerateBattleMessage) message;
            
            _generateBattleService.GenerateParticipantData(generateBattleMessage);
        }
    }
}