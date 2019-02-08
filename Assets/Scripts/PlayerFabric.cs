using Zenject;

namespace Game
{/// <summary>
/// Фабрика для создания игрока
/// </summary>
    class PlayerFabric: PlaceholderFactory<GameConfig, InputController, PlayerController>
    {
    }
}
