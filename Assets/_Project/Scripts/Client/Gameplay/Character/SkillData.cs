using System;
using _Project.Client.Core.Network.Messages;

namespace _Project.Client.Gameplay.Character
{
    [Serializable]
    public class SkillData
    {
        public SkillType Type;
        public int TimeAction;
        public int Recovery;
        public int Value;

        public bool IsActive => TimeAction > 0;
        public bool IsReady => Recovery == 0;

        public SkillData(SkillType type)
        {
            Type = type;
        }

        public SkillValueData ToValue() => 
            new SkillValueData(Type, TimeAction, Recovery, Value);
    }
}