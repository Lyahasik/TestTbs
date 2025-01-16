using System.Collections.Generic;
using _Project.Client.Core.Network.Messages;
using _Project.Client.Gameplay.Battle;
using TMPro;
using UnityEngine;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterStatsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthValueText;
        [SerializeField] private GameObject skillBarrier;

        public void SetStats(in ParticipantData participantData, List<SkillValueData> skillDataset)
        {
            healthValueText.text = participantData.Health.ToString();

            UpdateSkillsActive(skillDataset);
        }

        private void UpdateSkillsActive(List<SkillValueData> skillDataset) => 
            skillBarrier.SetActive(skillDataset.Find(data => data.Type == SkillType.Barrier).IsActive);
    }
}