using UnityEngine;

namespace Game
{
    /// <summary>
    /// Параметры игры
    /// </summary>
    [CreateAssetMenu(fileName ="GameConfig", menuName ="Create Config" )]
    class GameConfig:ScriptableObject
    {
        /// <summary>
        /// Скорость передвижения игрока
        /// </summary>
        public float PlayerMovementSpeed;
        /// <summary>
        /// Здоровье игрока
        /// </summary>
        public float PlayerHelth;
        /// <summary>
        /// Скорость стрельбы игрока
        /// </summary>
        public float PlayerShootTimeOut;
        /// <summary>
        /// Скорость появления противников
        /// </summary>
        public float EnemySpawnRate;
        /// <summary>
        /// Скорость передвижения противников
        /// </summary>
        public float EnemySpeed;
        /// <summary>
        /// Здоровье противников
        /// </summary>
        public float EnemyHealth;
        /// <summary>
        /// Скорость пули
        /// </summary>
        public float BulletAcceleration;
        /// <summary>
        /// Преваб игрока
        /// </summary>
        public BaseCharacterController PlayerPrefab;
        /// <summary>
        /// префаб врага
        /// </summary>
        public BaseCharacterController EnemyPrefab;
        /// <summary>
        /// Преваб ракеты
        /// </summary>
        public BaseAmmunition RocketPrefab;

    }
}
