using _Project.Constants;
using _Project.Meta.StaticData;
using UnityEngine;

namespace _Project.Core.StaticData.Services
{
    public class StaticDataService : IStaticDataService
    {
        private CoreStaticData _coreData;
        private GameplayStaticData _gameplayData;
        
        public CoreStaticData Core => _coreData;
        public GameplayStaticData Gameplay => _gameplayData;

        public void Load()
        {
            _coreData = Resources
                .Load<CoreStaticData>(ConstantPaths.CORE_DATA_PATH);
            
            _gameplayData = Resources
                .Load<GameplayStaticData>(ConstantPaths.GAMEPLAY_DATA_PATH);
            
            Debug.Log($"[{ GetType() }] initialize");
        }
    }
}