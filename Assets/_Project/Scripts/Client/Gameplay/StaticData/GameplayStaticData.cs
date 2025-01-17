using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Character;
using _Project.Client.Gameplay.Initialize;
using _Project.Client.UI.Gameplay.Hud;
using UnityEngine;

namespace _Project.Client.Gameplay.StaticData
{
    [CreateAssetMenu(fileName = "GameplayData", menuName = "Static data/Client/Gameplay")]
    public class GameplayStaticData : ScriptableObject
    {
        public InitializerGameplay initializerGameplayPrefab;

        [Space]
        public HudView hudViewPrefab;
        public GameplayBasis gameplayBasisPrefab;
        public CharacterView characterPrefab;
    }
}