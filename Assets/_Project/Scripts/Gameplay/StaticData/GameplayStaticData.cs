using _Project.Gameplay.Initialize;
using _Project.UI.Gameplay.Hud;
using UnityEngine;

namespace _Project.Meta.StaticData
{
    [CreateAssetMenu(fileName = "GameplayData", menuName = "Static data/Gameplay")]
    public class GameplayStaticData : ScriptableObject
    {
        public InitializerGameplay initializerGameplayPrefab;
        
        [Space]
        public HudView hudViewPrefab;
    }
}