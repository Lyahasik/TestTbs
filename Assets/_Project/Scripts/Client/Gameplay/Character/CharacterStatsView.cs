using _Project.Client.Gameplay.Battle;
using TMPro;
using UnityEngine;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterStatsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthValueText;

        public void SetStats(in ParticipantData participantData)
        {
            healthValueText.text = participantData.Health.ToString();
        }
    }
}