using UnityEngine;
using Zenject;
using Game.Signals;
namespace Game
{
    /// <summary>
    /// Служит для запуска и управления игрой
    /// </summary>
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на параметры игры
        /// </summary>
        [Inject]
        private GameConfig _config;
        /// <summary>
        /// Ссылка на контролер ссоздания персонажей
        /// </summary>
        [Inject]
        private SpawnController _spawnController;
        /// <summary>
        /// Ссылка шину с событиями
        /// </summary>
        [Inject]
        private SignalBus _signalBus;
        /// <summary>
        /// Ссылка на загрузчик сцен
        /// </summary>
        [Inject]
        private LoadManager _loadManager; 
       

        private void Start()
        {
            _signalBus.Subscribe<OnPlayerDead>(EndGame);
            _spawnController.SpawnPlayer();
            InvokeRepeating("SpawnEnemies", 0, _config.EnemySpawnRate);
        }
        /// <summary>
        /// загрузить игрока
        /// </summary>
        void SpawnPlayer()
        {
            _spawnController.SpawnPlayer();
        }
        /// <summary>
        /// загрузить врагов игрока
        /// </summary>
        void SpawnEnemies()
        {
            _spawnController.SpawnEnemies();
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        void EndGame()
        {
            _signalBus.Unsubscribe<OnPlayerDead>(EndGame);
            _loadManager.LoadScoresScene();
        }  
    }
}
