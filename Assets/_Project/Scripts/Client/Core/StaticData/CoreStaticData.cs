using _Project.Client.Core.Update;
using _Project.Client.UI.Loading;
using UnityEngine;

namespace _Project.Client.Core.StaticData
{
    [CreateAssetMenu(fileName = "CoreData", menuName = "Static data/Client/Core")]
    public class CoreStaticData : ScriptableObject
    {
        public UpdateHandler updateHandlerPrefab;
        public LoadingCurtain loadingCurtainPrefab;
        
        [Space]
        public float curtainDissolutionDelay;
        public float curtainDissolutionStep;
    }
}