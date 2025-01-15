using _Project.Client.Core.Network;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Battle;
using _Project.Server.Core.Network.ServerMessages;

namespace _Project.Server.Gameplay.Battle.Services
{
    public class GenerateBattleService : IGenerateBattleService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly NetworkMessengerClient _networkMessengerClient;

        public GenerateBattleService(IStaticDataService staticDataService, NetworkMessengerClient networkMessengerClient)
        {
            _staticDataService = staticDataService;
            _networkMessengerClient = networkMessengerClient;
        }
        
        public void GenerateParticipantData(GenerateBattleMessage message)
        {
            _networkMessengerClient.ReceiveMessage(new ParticipantsDataMessage
            {
                Player = new ParticipantData
                {
                    Health = _staticDataService.ServerGameplay.PlayerHealth,
                    Damage = _staticDataService.ServerGameplay.PlayerDamage
                },
                Enemy = new ParticipantData
                {
                    Health = _staticDataService.ServerGameplay.EnemyHealth,
                    Damage = _staticDataService.ServerGameplay.EnemyDamage
                }
            });
        }
    }
}