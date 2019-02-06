using Zenject;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO Installer", menuName ="Create SO installer")]
    class SOInstaller:ScriptableObjectInstaller
    {
        [SerializeField]
        private GameConfig _config;
        public override void InstallBindings()
        {
            Container.BindInstances(_config);
        }
    }
}
