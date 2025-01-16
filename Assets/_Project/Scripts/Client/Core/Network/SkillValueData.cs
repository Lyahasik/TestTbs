using _Project.Client.Core.Network.Messages;

namespace _Project.Client.Gameplay.Character
{
    public struct SkillValueData
    {
        public SkillType Type;
        public int TimeAction;
        public int Recovery;
        public int Value;

        public bool IsActive => TimeAction > 0;

        public SkillValueData(SkillType type, int timeAction, int recovery, int value)
        {
            Type = type;
            TimeAction = timeAction;
            Recovery = recovery;
            Value = value;
        }
    }
}