using _Project.Client.Core.Network;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Battle;
using _Project.Client.Gameplay.Character;
using _Project.Server.Core.Network.ServerMessages;

namespace _Project.Server.Gameplay.Battle.Services
{
    public class GenerateBattleService : IGenerateBattleService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly NetworkMessengerClient _networkMessengerClient;
        private readonly IProcessingBattleService _processingBattleService;

        public GenerateBattleService(IStaticDataService staticDataService,
            NetworkMessengerClient networkMessengerClient,
            IProcessingBattleService processingBattleService)
        {
            _staticDataService = staticDataService;
            _networkMessengerClient = networkMessengerClient;
            _processingBattleService = processingBattleService;
        }
        
        public void GenerateParticipantData(GenerateBattleMessage message)
        {
            var playerSkills = new CharacterSkills(new SkillData(SkillType.Barrier));
            var enemySkills = new CharacterSkills(new SkillData(SkillType.Barrier));
            
            var playerStats = new CharacterStats(
                _staticDataService.ServerGameplay.PlayerData.Health,
                _staticDataService.ServerGameplay.PlayerData.Damage,
                playerSkills);
            var enemyStats = new CharacterStats(
                _staticDataService.ServerGameplay.EnemyData.Health,
                _staticDataService.ServerGameplay.EnemyData.Damage,
                enemySkills);
            
            _processingBattleService.Initialize(playerStats, enemyStats);
            
            _networkMessengerClient.ReceiveMessage(new ParticipantsDataMessage
            {
                ParticipantPlayer = new ParticipantData { Health = playerStats.Health, Damage = playerStats.Damage },
                ParticipantEnemy = new ParticipantData { Health = enemyStats.Health, Damage = enemyStats.Damage }
            });
        }
    }
}