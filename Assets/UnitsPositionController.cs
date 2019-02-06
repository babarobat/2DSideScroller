using UnityEngine;
using Zenject;

namespace Game
{
    class UnitsPositionController
    {
        [Inject]
        private GameConfig _config;

        public Transform GetPlayerStartpos() => _config.PlayerSpawn;
        public Transform[] GetEnemiesStartPos() => _config.EnemySpawn;



    }
}
