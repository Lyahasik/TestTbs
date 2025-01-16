using System;

namespace _Project.Client.Gameplay.Character
{
    public class CharacterStats
    {
        private int _health;
        private int _damage;

        private CharacterSkills _characterSkills;

        public int Health => _health;
        public int Damage => _damage;
        public CharacterSkills Skills => _characterSkills;

        public CharacterStats(in int health, in int damage, CharacterSkills characterSkills)
        {
            _health = health;
            _damage = damage;

            _characterSkills = characterSkills;
        }

        public void LowerHealth(in int value) => 
            _health = Math.Max(_health - value, 0);
    }
}