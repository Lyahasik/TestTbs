using _Project.Core.Services;
using _Project.UI.Gameplay.Hud;

namespace _Project.Core.Factory.Gameplay
{
    public interface IGameplayFactory : IService
    {
        public HudView CreateHudView();
    }
}