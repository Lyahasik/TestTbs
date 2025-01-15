using _Project.Server.Core.Network;
using _Project.Server.Core.Network.ServerMessages;
using UnityEngine;

namespace _Project.Client.Gameplay.Battle.Services
{
    public class CreateBattleService : ICreateBattleService
    {
        private readonly NetworkMessengerServer _networkMessengerServer;

        public CreateBattleService(NetworkMessengerServer networkMessengerServer)
        {
            _networkMessengerServer = networkMessengerServer;
        }

        public void RequestBattleData()
        {
            _networkMessengerServer.ReceiveMessage(new GenerateBattleMessage());
        }

        public void CreateBattle(in ParticipantData playerData, in ParticipantData enemyData)
        {
            Debug.Log($"Player: {playerData.Health}, {playerData.Damage}");
        }
    }
}