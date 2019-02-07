using UnityEngine;
using Zenject;

namespace Game
{
    class SpawnController:MonoBehaviour

    {
        [Inject]
        private GameConfig _config;
        [Inject]
        private EnemyFabric _enemyFabric;
        [Inject]
        private PlayerFabric _playerFabric;
        [SerializeField]
        private Transform _playerSpawnpoint;
        public Vector2 PlayerSpawnPoint =>_playerSpawnpoint.position;
        [SerializeField]
        private Transform [] _enemySpawnPoints;

        
       
        [Inject]
        InputController _inputController;

        
        public void SpawnPlayer()
        {
            var player = _playerFabric.Create(_config, _inputController);
            player.transform.position = _playerSpawnpoint.position;
        }
        public void SpawnEnemy()
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
