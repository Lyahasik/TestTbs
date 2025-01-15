using _Project.Core.StaticData.Services;
using _Project.UI.Gameplay.Hud;

namespace _Project.Core.Factory.Gameplay
{
    public class GameplayFactory : Factory, IGameplayFactory
    {
        private readonly IStaticDataService _staticDataService;

        public GameplayFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public HudView CreateHudView() => 
            PrefabInstantiate(_staticDataService.Gameplay.hudViewPrefab);
    }
}