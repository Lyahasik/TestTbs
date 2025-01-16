using _Project.Client.Core.Network.Messages;
using _Project.Network;
using _Project.Server.Core.Network.ServerMessages;
using _Project.Server.Gameplay.Battle.Services;

namespace _Project.Server.Core.Network
{
    public class NetworkMessengerServer : NetworkMessenger
    {
        private IGenerateBattleService _generateBattleService;
        private IProcessingBattleService _processingBattleService;
        
        public void Initialize(IGenerateBattleService generateBattleService,
            IProcessingBattleService processingBattleService)
        {
            _generateBattleService = generateBattleService;
            _processingBattleService = processingBattleService;
            
            _messageHandlers = new ();
            
            RegisterHandler<GenerateBattleMessage>(OnReceiveGenerateBattleMessage);
            RegisterHandler<StepDataMessage>(OnReceiveStepMessage);
        }

        private void OnReceiveGenerateBattleMessage(INetworkMessage message) => 
            _generateBattleService.GenerateParticipantData((GenerateBattleMessage) message);

        private void OnReceiveStepMessage(INetworkMessage message) => 
            _processingBattleService.ProcessingStep((StepDataMessage) message);
    }
}