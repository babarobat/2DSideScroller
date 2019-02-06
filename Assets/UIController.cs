using UnityEngine;
using Zenject;

namespace Game
{
    class UIController:MonoBehaviour
    {
        [Inject]
        private GameController _gameController;
    }
}
