namespace _Project.Client.Gameplay.Character
{
    public class CharacterStats
    {
        private int _health;
        private int _damage;

        public int Health => _health;
        public int Damage => _damage;

        public CharacterStats(in int health, in int damage)
        {
            _health = health;
            _damage = damage;
        }

        public void LowerHealth(in int value) => 
            _health -= value;
    }
}