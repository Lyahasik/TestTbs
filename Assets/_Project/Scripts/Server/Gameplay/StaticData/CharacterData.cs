using System;
using System.Collections.Generic;
using _Project.Client.Gameplay.Character;

namespace _Project.Server.Gameplay.StaticData
{
    [Serializable]
    public class CharacterData
    {
        public int Health;
        public int Damage;

        public List<SkillData> SkillDataset;
    }
}