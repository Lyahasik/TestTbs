using UnityEngine;

namespace _Project.Server.Gameplay.StaticData
{
    [CreateAssetMenu(fileName = "GameplayData", menuName = "Static data/Server/Gameplay")]
    public class GameplayStaticData : ScriptableObject
    {
        public int PlayerHealth;
        public int PlayerDamage;
        
        [Space]
        public int EnemyHealth;
        public int EnemyDamage;
    }
}