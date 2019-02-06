using Zenject;

namespace Game
{
    class GameInstaller:MonoInstaller
    {
        public override void InstallBindings()
        {
            
            Container.Bind<UnitsPositionController>().AsSingle();

            
        }
    }
}
