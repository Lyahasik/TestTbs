using System.Collections;
using System.Collections.Generic;
using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Battle.Services;
using _Project.Client.Gameplay.Character;
using _Project.Server.Core.Network.ServerMessages;
using _Project.Server.Gameplay.Battle.Services;
using UnityEngine;

namespace _Project.Client.UI.Gameplay.Hud
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private GameObject gameEndView;
        
        [Space]
        [SerializeField] private SkillButton attackButton;
        [SerializeField] private SkillButton barrierButton;

        private IStaticDataService _staticDataService;
        private ICoroutineRunnerService _coroutineRunnerService;
        private IGenerateBattleService _generateBattleService;
        private IProcessingRequestStepService _processingRequestStepService;
        
        private List<SkillValueData> _playerSkills;
        private List<SkillValueData> _enemySkills;

        public void Construct(IStaticDataService staticDataService,
            IGenerateBattleService generateBattleService,
            ICoroutineRunnerService coroutineRunnerService,
            IProcessingRequestStepService processingRequestStepService)
        {
            _staticDataService = staticDataService;
            _generateBattleService = generateBattleService;
            _coroutineRunnerService = coroutineRunnerService;
            _processingRequestStepService = processingRequestStepService;
        }

        public void StartGame(List<SkillValueData> playerSkills)
        {
            gameEndView.SetActive(false);
            
            _playerSkills = playerSkills;
            
            UpdateSkills();
        }

        public void GameEnd()
        {
            gameEndView.SetActive(true);
        }

        public void Attack()
        {
            _processingRequestStepService.RequestAttack();
        }

        public void Barrier()
        {
            _processingRequestStepService.RequestBarrier();
        }

        public void ShowStep(List<SkillValueData> playerSkills)
        {
            _playerSkills = playerSkills;
            
            attackButton.interactable = false;
            barrierButton.interactable = false;

            _coroutineRunnerService.StartCoroutine(Ready());
        }

        public void Restart()
        {
            _coroutineRunnerService.StopAllCoroutines();
            _generateBattleService.GenerateParticipantData(new GenerateBattleMessage());
        }

        private IEnumerator Ready()
        {
            yield return new WaitForSeconds(1f);
            
            UpdateSkills();
        }

        private void UpdateSkills()
        {
            attackButton.SetRecovery(0);
            barrierButton.SetRecovery(
                _playerSkills.Find(data => data.Type == SkillType.Barrier).Recovery,
                _staticDataService.GetPlayerSkillData(SkillType.Barrier).Recovery);
        }
    }
}
