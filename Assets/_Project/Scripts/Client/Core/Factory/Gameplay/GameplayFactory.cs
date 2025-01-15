using _Project.Client.Core.StaticData.Services;
using _Project.Client.UI.Gameplay.Hud;

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
    }
}