using _Project.Client.Core.Services;
using _Project.Client.Gameplay.Basis;
using _Project.Client.Gameplay.Character;
using _Project.Client.UI.Gameplay.Hud;
using UnityEngine;

namespace _Project.Client.Core.Factory.Gameplay
{
    public interface IGameplayFactory : IService
    {
        public HudView CreateHudView();
        public GameplayBasis CreateGameplayBasis();
        public CharacterView CreateCharacter(Transform spawnPoint);
    }
}