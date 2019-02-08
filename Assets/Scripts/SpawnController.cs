using UnityEngine;
using Zenject;

namespace Game
{
   /// <summary>
   /// Управляет созданием обьектов в игре
   /// </summary>
    class SpawnController:MonoBehaviour
    {
        /// <summary>
        /// Параметры игры
        /// </summary>
        [Inject]
        private GameConfig _config;
        /// <summary>
        /// Фабрика по созданию обьектов типа EnemieController
        /// </summary>
        [Inject]
        private EnemyFabric _enemyFabric;
        /// <summary>
        /// Фабрика по созданию обьектов типа PLayerController
        /// </summary>
        [Inject]
        private PlayerFabric _playerFabric;
        /// <summary>
        /// Точка появления игрока
        /// </summary>
        [SerializeField]
        private Transform _playerSpawnpoint;
        /// <summary>
        /// Точка появления игрока
        /// </summary>
        public Vector2 PlayerSpawnPoint =>_playerSpawnpoint.position;
        /// <summary>
        /// Точка появления противников
        /// </summary>
        [SerializeField]
        private Transform [] _enemySpawnPoints;

        
       /// <summary>
       /// Ссылка на обработчик пользовательских комманд
       /// </summary>
        [Inject]
        InputController _inputController;

        /// <summary>
        /// Создать обьек типа PlayerController
        /// </summary>
        public void SpawnPlayer()
        {
            var player = _playerFabric.Create(_config, _inputController);
            player.transform.position = _playerSpawnpoint.position;
        }
        /// <summary>
        /// Создать обьекты типа EnemieController
        /// </summary>
        public void SpawnEnemies()
        {
            foreach (var item in _enemySpawnPoints)
            {
                var enemyDir = _playerSpawnpoint.position.x < item.position.x ? -1:1;
                var tmpEnemy = _enemyFabric.Create(_config,enemyDir);
                tmpEnemy.transform.position = item.position ;
            }
            
        }
    }
}
