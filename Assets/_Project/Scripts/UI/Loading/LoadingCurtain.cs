using System.Collections;
using _Project.Core.Coroutines;
using _Project.Core.StaticData.Services;
using UnityEngine;

namespace _Project.UI.Loading
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup curtain;

        private IStaticDataService _staticDataService;

        private WaitForSeconds _dissolutionDelay;

        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            name = _staticDataService.Core.loadingCurtainPrefab.name;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            curtain.alpha = 1;
        }

        public void Hide(ICoroutineRunnerService container) =>
            container.StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            _dissolutionDelay ??= new WaitForSeconds(_staticDataService.Core.curtainDissolutionDelay);
            
            while (curtain.alpha > 0)
            {
                curtain.alpha -= _staticDataService.Core.curtainDissolutionStep;
                yield return _dissolutionDelay;
            }
      
            gameObject.SetActive(false);
        }
    }
}