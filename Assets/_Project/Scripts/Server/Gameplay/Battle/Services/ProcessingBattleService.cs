using System.Collections;
using System.Linq;
using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Network;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Battle;
using _Project.Client.Gameplay.Character;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Server.Gameplay.Battle.Services
{
    public class ProcessingBattleService : IProcessingBattleService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ICoroutineRunnerService _coroutineRunnerService;
        private readonly NetworkMessengerClient _networkMessengerClient;

        private CharacterStats _playerStats;
        private CharacterStats _enemyStats;

        public ProcessingBattleService(IStaticDataService staticDataService,
            ICoroutineRunnerService coroutineRunnerService,
            NetworkMessengerClient networkMessengerClient)
        {
            _staticDataService = staticDataService;
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
                ParticipantPlayer = new ParticipantData { Health = _playerStats.Health, Damage = _playerStats.Damage },
                SkillsPlayer = _playerStats.Skills.GetSkillValueDataset(),
                ParticipantEnemy = new ParticipantData { Health = _enemyStats.Health, Damage = _enemyStats.Damage },
                SkillsEnemy = _enemyStats.Skills.GetSkillValueDataset(),
            });
        }

        private void ProcessingStepPlayer(in StepDataMessage stepDataMessage)
        {
            switch (stepDataMessage.SkillType)
            {
                case SkillType.Attack:
                    Debug.Log($"Player attack.");
                    CauseDamage(_playerStats, _enemyStats);
                    break;
                case SkillType.Barrier:
                    ActivateBarrier(_playerStats, true);
                    Debug.Log($"Player barrier activate");
                    break;
            }

            LowerRecoverySkills(_playerStats);
            
            ReceiveResult();
        }

        private IEnumerator ProcessingStepEnemy()
        {
            yield return new WaitForSeconds(1f);

            var skillTypeId = Random.Range(0, 1);
            switch ((SkillType) skillTypeId)
            {
                case SkillType.Attack:
                    Debug.Log($"Enemy attack.");
                    CauseDamage(_enemyStats, _playerStats);
                    break;
                case SkillType.Barrier:
                    ActivateBarrier(_enemyStats, false);
                    Debug.Log($"Enemy barrier activate");
                    break;
            }

            LowerRecoverySkills(_enemyStats);
            
            ReceiveResult();
        }

        private void ActivateBarrier(CharacterStats characterStats, in bool isPlayer)
        {
            SkillData skillStaticData = isPlayer
                ? _staticDataService.GetPlayerSkillData(SkillType.Barrier)
                : _staticDataService.GetEnemySkillData(SkillType.Barrier);
            SkillData skillData = characterStats.Skills.GetSkillData(SkillType.Barrier);

            skillData.TimeAction = skillStaticData.TimeAction;
            skillData.Recovery = skillStaticData.Recovery;
            skillData.Value = skillStaticData.Value;
        }

        private void CauseDamage(CharacterStats attakingStats, CharacterStats targetStats)
        {
            var totalDamage = attakingStats.Damage;

            var skillBarrier = targetStats.Skills.GetSkillData(SkillType.Barrier);
            if (skillBarrier.IsActive)
            {
                if (skillBarrier.Value > totalDamage)
                {
                    skillBarrier.Value -= totalDamage;
                    totalDamage = 0;
                }
                else
                {
                    totalDamage -= skillBarrier.Value;
                    skillBarrier.TimeAction = 0;
                    skillBarrier.Value = 0;
                }
            }
            
            Debug.Log($"Damage: { totalDamage }");
            targetStats.LowerHealth(totalDamage);
        }

        private void LowerRecoverySkills(CharacterStats characterStats)
        {
            characterStats.Skills.SkillDataset.ForEach(data =>
            {
                if (data.IsReady)
                    return;
                
                data.Recovery--;
                if (data.TimeAction > 0)
                    data.TimeAction--;
            });
        }
    }
}