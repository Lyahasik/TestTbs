using System.Collections.Generic;
using _Project.Client.Core.Network.Messages;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterSkills
    {
        private readonly List<SkillData> _skillDataset;

        public List<SkillData> SkillDataset => _skillDataset;

        public CharacterSkills(in SkillData barrierData,
            in SkillData restoreData,
            in SkillData fireData,
            in SkillData clearData)
        {
            _skillDataset = new List<SkillData>
            {
                barrierData,
                restoreData,
                fireData,
                clearData
            };
        }

        public SkillData GetSkillData(SkillType skillType) =>
            _skillDataset.Find(data => data.Type == skillType);

        public List<SkillValueData> GetSkillValueDataset()
        {
            var skillValueDataset = new List<SkillValueData>();
            _skillDataset.ForEach(data => skillValueDataset.Add(data.ToValue()));

            return skillValueDataset;
        }
    }
}