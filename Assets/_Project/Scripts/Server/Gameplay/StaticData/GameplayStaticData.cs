using UnityEngine;

namespace _Project.Server.Gameplay.StaticData
{
    [CreateAssetMenu(fileName = "GameplayData", menuName = "Static data/Server/Gameplay")]
    public class GameplayStaticData : ScriptableObject
    {
        public int FireDamage;
        
        public CharacterData PlayerData;
        public CharacterData EnemyData;
    }
}