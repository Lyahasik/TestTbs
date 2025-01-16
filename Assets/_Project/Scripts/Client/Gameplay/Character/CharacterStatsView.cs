using TMPro;
using UnityEngine;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterStatsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthValueText;

        public void SetStats(CharacterStats characterStats)
        {
            healthValueText.text = characterStats.Health.ToString();
        }
    }
}