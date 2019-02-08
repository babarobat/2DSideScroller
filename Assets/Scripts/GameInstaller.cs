using Zenject;
using Game.Signals;
namespace Game
{
    /// <summary>
    /// загружает инъекции
    /// </summary>
    class GameInstaller:MonoInstaller<GameInstaller>
    {
        /// <summary>
        /// Ссылка на параметры игры
        /// </summary>
        [Inject]
        GameConfig _config;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.BindFactory<GameConfig, InputController, PlayerController,PlayerFabric>().FromComponentInNewPrefab(_config.PlayerPrefab);
            Container.BindFactory<GameConfig,int, EnemyController, EnemyFabric>().FromComponentInNewPrefab(_config.EnemyPrefab);
            Container.BindFactory<GameConfig, Rocket ,RocketFactory>().FromComponentInNewPrefab(_config.RocketPrefab);
            Container.DeclareSignal<OnPlayerDead>();
            

        }
    }
}
