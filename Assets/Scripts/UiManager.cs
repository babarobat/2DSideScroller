using UnityEngine;
using Zenject;

namespace Game
{
    /// <summary>
    /// Содержит ссылки на элементы UI игрогвой сцены и логику взаимодействия игрока с пользовательским интерфейсом 
    /// </summary>
    class UiManager:MonoBehaviour
    {
        /// <summary>
        /// Ссылка на обработчик пользовательских комманд
        /// </summary>
        [Inject]
        InputController _input;
        /// <summary>
        /// Назначить значение по оси Horizontal 
        /// </summary>
        /// <param name="value"></param>
        public void SetHor(int value)
        {
            _input.SetHorRaw(value);
        }
        /// <summary>
        /// Назначить значение команды Fire
        /// </summary>
        /// <param name="value"></param>
        public void Fire(bool value )
        {
            _input.SetFire(value);
        }


    }
}
