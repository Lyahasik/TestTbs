using _Project.Client.Gameplay.Battle;
using UnityEngine;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private CharacterStatsView characterStatsView;
        
        private CharacterStats _characterStats;

        public void Construct(in ParticipantData participantData)
        {
            _characterStats = new CharacterStats { Health = participantData.Health, Damage = participantData.Damage};
        }

        public void Initialize()
        {
            characterStatsView.SetStats(_characterStats);
        }
    }
}