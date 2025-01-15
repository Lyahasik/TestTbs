using _Project.Core.Coroutines;
using _Project.UI.Loading;
using UnityEngine;

namespace _Project.Core.Initialize
{
    public class CoreData : MonoBehaviour
    {
        private LoadingCurtain _curtain;
        private CoroutinesContainer _coroutinesContainer;
        public CoroutinesContainer CoroutinesContainer => _coroutinesContainer;
        public LoadingCurtain Curtain => _curtain;

        public void Construct(LoadingCurtain curtain,
            CoroutinesContainer coroutinesContainer)
        {
            _curtain = curtain;
            _coroutinesContainer = coroutinesContainer;
        }
    }
}