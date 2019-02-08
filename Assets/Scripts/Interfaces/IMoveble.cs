using UnityEngine;
namespace Game.Interfaces
{
   /// <summary>
   /// Логика движения
   /// </summary>
    public interface IMoveble
    {
        /// <summary>
        /// Двигаться
        /// </summary>
        /// <param name="dir">направление</param>
        /// <param name="speed">скорость</param>
        void Move(Vector2 dir, float speed);
    }
}
