using _Project.Core.Update;
using _Project.UI.Loading;
using UnityEngine;

namespace _Project.Meta.StaticData
{
    [CreateAssetMenu(fileName = "CoreData", menuName = "Static data/Core")]
    public class CoreStaticData : ScriptableObject
    {
        public UpdateHandler updateHandlerPrefab;
        public LoadingCurtain loadingCurtainPrefab;
        
        [Space]
        public float curtainDissolutionDelay;
        public float curtainDissolutionStep;
    }
}