using _Project.Client.Gameplay.Battle;
using UnityEngine;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private CharacterStatsView characterStatsView;

        public void SetStats(in ParticipantData participantData)
        {
            characterStatsView.SetStats(participantData);
        }
    }
}