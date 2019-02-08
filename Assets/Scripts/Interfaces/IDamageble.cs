
namespace Game.Interfaces
{
    /// <summary>
    /// Определяет поведение при получении урона
    /// </summary>
    public interface IDamageble
    {
        /// <summary>
        /// Получить урон
        /// </summary>
        /// <param name="damage">колличество урона</param>
        void GetDamage(float damage);
    }
}
