using System.Collections;
using _Project.Client.Core.Coroutines;
using _Project.Client.Gameplay.Battle.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Client.UI.Gameplay.Hud
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private Button attackButton;

        private  ICoroutineRunnerService _coroutineRunnerService;
        private IProcessingRequestStepService _processingRequestStepService;

        public void Construct(ICoroutineRunnerService coroutineRunnerService,
            IProcessingRequestStepService processingRequestStepService)
        {
            _coroutineRunnerService = coroutineRunnerService;
            _processingRequestStepService = processingRequestStepService;
        }
        
        public void Attack()
        {
            _processingRequestStepService.RequestAttack();
        }

        public void ShowStep()
        {
            attackButton.interactable = false;

            _coroutineRunnerService.StartCoroutine(Ready());
        }
        
        public IEnumerator Ready()
        {
            yield return new WaitForSeconds(1f);
            
            attackButton.interactable = true;
        }
    }
}
