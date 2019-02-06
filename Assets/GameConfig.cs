using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName ="GameConfig", menuName ="Create Config" )]
    class GameConfig:ScriptableObject
    {
        public float PlayerMovementSpeed;
        public float PlayerShootTimeOut;
        public float EnemySpawnRate;
        public float BulletAcceleration;
        public BaseCharacterController PlayerPrefab;
        public BaseCharacterController EnemyPrefab;
        public Transform PlayerSpawn;
        public Transform[] EnemySpawn;


    }
}
