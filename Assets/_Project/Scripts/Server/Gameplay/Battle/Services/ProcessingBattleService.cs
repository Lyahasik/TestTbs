using System.Collections;
using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Network;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Gameplay.Battle;
using _Project.Client.Gameplay.Character;
using UnityEngine;

namespace _Project.Server.Gameplay.Battle.Services
{
    public class ProcessingBattleService : IProcessingBattleService
    {
        private readonly ICoroutineRunnerService _coroutineRunnerService;
        private readonly NetworkMessengerClient _networkMessengerClient;

        private CharacterStats _playerStats;
        private CharacterStats _enemyStats;

        public ProcessingBattleService(ICoroutineRunnerService coroutineRunnerService,
            NetworkMessengerClient networkMessengerClient)
        {
            _coroutineRunnerService = coroutineRunnerService;
            _networkMessengerClient = networkMessengerClient;
        }

        public void Initialize(CharacterStats playerStats, CharacterStats enemyStats)
        {
            _playerStats = playerStats;
            _enemyStats = enemyStats;
        }

        public void ProcessingStep(in StepDataMessage stepDataMessage)
        {
            ProcessingStepPlayer(stepDataMessage);
            
            _coroutineRunnerService.StartCoroutine(ProcessingStepEnemy());
        }

        private void ReceiveResult()
        {
            _networkMessengerClient.ReceiveMessage(new UpdateStatsDataMessage
            {
                Player = new ParticipantData { Health = _playerStats.Health, Damage = _playerStats.Damage },
                Enemy = new ParticipantData { Health = _enemyStats.Health, Damage = _enemyStats.Damage }
            });
        }

        private void ProcessingStepPlayer(in StepDataMessage stepDataMessage)
        {
            switch (stepDataMessage.SkillType)
            {
                case SkillType.Attack:
                    CauseDamage(_playerStats, _enemyStats);
                    Debug.Log($"Player attack: { _playerStats.Damage } ");
                    break;
            }
            
            ReceiveResult();
        }

        private IEnumerator ProcessingStepEnemy()
        {
            yield return new WaitForSeconds(1f);
            
            CauseDamage(_enemyStats, _playerStats);
            Debug.Log($"Enemy attack: { _enemyStats.Damage } ");
            
            ReceiveResult();
        }

        private void CauseDamage(CharacterStats attakingStats, CharacterStats targetStats) => 
            targetStats.LowerHealth(attakingStats.Damage);
    }
}