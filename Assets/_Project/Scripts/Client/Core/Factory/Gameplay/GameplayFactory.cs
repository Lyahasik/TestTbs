using _Project.Client.Core.StaticData.Services;
using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Character;
using _Project.Client.UI.Gameplay.Hud;
using UnityEngine;

namespace _Project.Client.Core.Factory.Gameplay
{
    public class GameplayFactory : Factory, IGameplayFactory
    {
        private readonly IStaticDataService _staticDataService;

        public GameplayFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public HudView CreateHudView() => 
            PrefabInstantiate(_staticDataService.ClientGameplay.hudViewPrefab);

        public GameplayBasis CreateGameplayBasis() => 
            PrefabInstantiate(_staticDataService.ClientGameplay.gameplayBasisPrefab);

        public CharacterView CreateCharacter(Transform spawnPoint) =>
            PrefabInstantiate(_staticDataService.ClientGameplay.characterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}