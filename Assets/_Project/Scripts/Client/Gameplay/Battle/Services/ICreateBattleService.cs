using _Project.Client.Core.Services;

namespace _Project.Client.Gameplay.Battle.Services
{
    public interface ICreateBattleService : IService
    {
        public void RequestBattleData();
        public void CreateBattle(in ParticipantData playerData, in ParticipantData enemyData);
    }
}