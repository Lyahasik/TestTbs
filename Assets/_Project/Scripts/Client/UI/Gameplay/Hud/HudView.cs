using System.Collections;
using System.Collections.Generic;
using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Battle.Services;
using _Project.Client.Gameplay.Character;
using UnityEngine;

namespace _Project.Client.UI.Gameplay.Hud
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private SkillButton attackButton;
        
        [SerializeField] private SkillButton barrierButton;

        private IStaticDataService _staticDataService;
        private ICoroutineRunnerService _coroutineRunnerService;
        private IProcessingRequestStepService _processingRequestStepService;
        
        private List<SkillValueData> _playerSkills;
        private List<SkillValueData> _enemySkills;

        public void Construct(IStaticDataService staticDataService,
            ICoroutineRunnerService coroutineRunnerService,
            IProcessingRequestStepService processingRequestStepService)
        {
            _staticDataService = staticDataService;
            _coroutineRunnerService = coroutineRunnerService;
            _processingRequestStepService = processingRequestStepService;
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
        
        public IEnumerator Ready()
        {
            yield return new WaitForSeconds(1f);
            
            attackButton.SetRecovery(0);
            barrierButton.SetRecovery(
                _playerSkills.Find(data => data.Type == SkillType.Barrier).Recovery,
                _staticDataService.GetPlayerSkillData(SkillType.Barrier).Recovery);
        }
    }
}
