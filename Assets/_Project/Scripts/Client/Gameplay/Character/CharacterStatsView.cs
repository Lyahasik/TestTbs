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
        [SerializeField] private GameObject skillRestore;
        [SerializeField] private GameObject skillFire;

        public void SetStats(in ParticipantData participantData,
            List<SkillValueData> playerDataset,
            List<SkillValueData> enemyDataset)
        {
            healthValueText.text = participantData.Health.ToString();

            UpdateSkillsActive(playerDataset, enemyDataset);
        }

        private void UpdateSkillsActive(List<SkillValueData> playerDataset, List<SkillValueData> enemyDataset)
        {
            skillBarrier.SetActive(playerDataset.Find(data => data.Type == SkillType.Barrier).IsActive);
            skillRestore.SetActive(playerDataset.Find(data => data.Type == SkillType.Restore).IsActive);
            skillFire.SetActive(enemyDataset.Find(data => data.Type == SkillType.Fire).IsActive);
        }
    }
}