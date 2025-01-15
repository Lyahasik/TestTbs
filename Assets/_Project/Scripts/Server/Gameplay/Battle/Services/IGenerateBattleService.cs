using _Project.Client.Core.Services;
using _Project.Server.Core.Network.ServerMessages;

namespace _Project.Server.Gameplay.Battle.Services
{
    public interface IGenerateBattleService : IService
    {
        public void GenerateParticipantData(GenerateBattleMessage message);
    }
}