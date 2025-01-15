using _Project.Client.Core.Services;
using _Project.Client.UI.Gameplay.Hud;

namespace _Project.Client.Core.Factory.Gameplay
{
    public interface IGameplayFactory : IService
    {
        public HudView CreateHudView();
    }
}