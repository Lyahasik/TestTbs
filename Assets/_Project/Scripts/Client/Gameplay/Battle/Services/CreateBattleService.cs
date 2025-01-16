using _Project.Client.Core.Factory.Gameplay;
using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Character;
using _Project.Server.Core.Network;
using _Project.Server.Core.Network.ServerMessages;

namespace _Project.Client.Gameplay.Battle.Services
{
    public class CreateBattleService : ICreateBattleService
    {
        private readonly IGameplayFactory _gameplayFactory;
        private readonly NetworkMessengerServer _networkMessengerServer;
        private readonly GameplayBasis _gameplayBasis;
        
        private CharacterView _player;
        private CharacterView _enemy;

        public CharacterView Player => _player;
        public CharacterView Enemy => _enemy;

        public CreateBattleService(IGameplayFactory gameplayFactory,
            NetworkMessengerServer networkMessengerServer,
            GameplayBasis gameplayBasis)
        {
            _gameplayFactory = gameplayFactory;
            _networkMessengerServer = networkMessengerServer;
            _gameplayBasis = gameplayBasis;
        }

        public void RequestBattleData()
        {
            _networkMessengerServer.ReceiveMessage(new GenerateBattleMessage());
        }

        public void CreateBattle(in ParticipantData playerData, in ParticipantData enemyData)
        {
            _player = _gameplayFactory.CreateCharacter(_gameplayBasis.SpawnPointPlayer);
            _player.SetStats(playerData);
            
            _enemy = _gameplayFactory.CreateCharacter(_gameplayBasis.SpawnPointEnemy);
            _enemy.SetStats(enemyData);
        }
    }
}