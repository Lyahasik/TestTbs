using UnityEngine;

namespace _Project.Client.Gameplay.Basis
{
    public class GameplayBasis : MonoBehaviour
    {
        [SerializeField] private Transform spawnPointPlayer;
        [SerializeField] private Transform spawnPointEnemy;

        public Transform SpawnPointPlayer => spawnPointPlayer;
        public Transform SpawnPointEnemy => spawnPointEnemy;
    }
}