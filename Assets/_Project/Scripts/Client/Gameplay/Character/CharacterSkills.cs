using System.Collections.Generic;
using _Project.Client.Core.Network.Messages;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterSkills
    {
        private readonly List<SkillData> _skillDataset;

        public List<SkillData> SkillDataset => _skillDataset;

        public CharacterSkills(in SkillData barrierData)
        {
            _skillDataset = new List<SkillData>
            {
                barrierData
            };
        }

        public SkillData GetSkillData(SkillType skillType) =>
            _skillDataset.Find(data => data.Type == skillType);

        public List<SkillValueData> GetSkillDataset()
        {
            var skillValueDataset = new List<SkillValueData>();
            _skillDataset.ForEach(data => skillValueDataset.Add(data.ToValue()));

            return skillValueDataset;
        }

        public void SetTimeAction(SkillType skillType, in int value) => 
            GetSkillData(skillType).TimeAction = value;

        public void LowerTimeAction(SkillType skillType, in int value) =>
            GetSkillData(skillType).TimeAction -= value;

        public void SetRecovery(SkillType skillType, in int value) => 
            GetSkillData(skillType).Recovery = value;

        public void LowerRecovery(SkillType skillType, in int value) =>
            GetSkillData(skillType).Recovery -= value;

        public void SetValue(SkillType skillType, in int value) => 
            GetSkillData(skillType).Value = value;
        public int GetValue(SkillType skillType) => 
            GetSkillData(skillType).Value;

        public void LowerValue(SkillType skillType, in int value) =>
            GetSkillData(skillType).Value -= value;
    }
}