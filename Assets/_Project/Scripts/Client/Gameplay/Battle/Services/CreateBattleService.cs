using System.Collections.Generic;
using _Project.Client.Core.Factory.Gameplay;
using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Character;
using _Project.Client.UI.Gameplay.Hud;
using _Project.Server.Core.Network;
using _Project.Server.Core.Network.ServerMessages;

namespace _Project.Client.Gameplay.Battle.Services
{
    public class CreateBattleService : ICreateBattleService
    {
        private readonly IGameplayFactory _gameplayFactory;
        private readonly NetworkMessengerServer _networkMessengerServer;
        private readonly GameplayBasis _gameplayBasis;

        private HudView _hudView;
        private CharacterView _player;
        private CharacterView _enemy;

        public CharacterView Player => _player;
        public CharacterView Enemy => _enemy;

        public CreateBattleService(IGameplayFactory gameplayFactory,
            NetworkMessengerServer networkMessengerServer,
            GameplayBasis gameplayBasis,
            HudView hudView)
        {
            _gameplayFactory = gameplayFactory;
            _networkMessengerServer = networkMessengerServer;
            _gameplayBasis = gameplayBasis;
            _hudView = hudView;
        }

        public void RequestBattleData()
        {
            _networkMessengerServer.ReceiveMessage(new GenerateBattleMessage());
        }

        public void CreateBattle(in ParticipantData playerData,
            List<SkillValueData> playerSkills,
            in ParticipantData enemyData,
            List<SkillValueData> enemySkills)
        {
            _hudView.StartGame(playerSkills);
            
            _player = _gameplayFactory.CreateCharacter(_gameplayBasis.SpawnPointPlayer);
            _player.SetStats(playerData, playerSkills);
            
            _enemy = _gameplayFactory.CreateCharacter(_gameplayBasis.SpawnPointEnemy);
            _enemy.SetStats(enemyData, enemySkills);
        }
    }
}