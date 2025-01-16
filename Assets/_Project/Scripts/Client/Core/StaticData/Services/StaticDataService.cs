using _Project.Client.Core.Network.Messages;
using _Project.Client.Gameplay.Character;
using _Project.Constants;
using UnityEngine;

using ClientGameplayStaticData = _Project.Client.Gameplay.StaticData.GameplayStaticData;
using ServerGameplayStaticData = _Project.Server.Gameplay.StaticData.GameplayStaticData;

namespace _Project.Client.Core.StaticData.Services
{
    public class StaticDataService : IStaticDataService
    {
        private CoreStaticData _coreData;
        private ClientGameplayStaticData _clientGameplayData;
        private ServerGameplayStaticData _serverGameplayData;
        
        public CoreStaticData Core => _coreData;
        public ClientGameplayStaticData ClientGameplay => _clientGameplayData;
        public ServerGameplayStaticData ServerGameplay => _serverGameplayData;

        public void Load()
        {
            _coreData = Resources
                .Load<CoreStaticData>(ConstantPaths.CLIENT_CORE_DATA_PATH);
            _clientGameplayData = Resources
                .Load<ClientGameplayStaticData>(ConstantPaths.CLIENT_GAMEPLAY_DATA_PATH);
            
            _serverGameplayData = Resources
                .Load<ServerGameplayStaticData>(ConstantPaths.SERVER_GAMEPLAY_DATA_PATH);
            
            Debug.Log($"[{ GetType() }] initialize");
        }

        public SkillData GetPlayerSkillData(SkillType skillType) => 
            ServerGameplay.PlayerData.SkillDataset.Find(data => data.Type == skillType);

        public SkillData GetEnemySkillData(SkillType skillType) => 
            ServerGameplay.PlayerData.SkillDataset.Find(data => data.Type == skillType);
    }
}