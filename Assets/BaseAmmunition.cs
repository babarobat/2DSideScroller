using UnityEngine;
using Game.Interfaces;

namespace Game
{
    /// <summary>
    /// Базовый класс снарядов
    /// </summary>
    public abstract class BaseAmmunition:BaseObjScene
    {
        /// <summary>
        /// Скорость снаряда
        /// </summary>
        protected float _speed;

        /// <summary>
        /// Скорость снаряда
        /// </summary>
        public float Speed
        {
            get => _speed;
            set => _speed = value < 0 ? 0 : value; 
        }
        /// <summary>
        /// Урон
        /// </summary>
        protected float _damage;
        /// <summary>
        /// Урон
        /// </summary>
        public float Damage
        {
            get => _damage;
            set => _damage = value < 0 ? 0 : value;
        }
        /// <summary>
        /// Логика столкновения. 
        /// </summary>
        /// <param name="collision"></param>
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            SetDamage(collision.transform.GetComponent<IDamageble>(), Damage);
            Destroy(gameObject);
            return;
        }
        /// <summary>
        /// Наносит урон
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="damage"></param>
        protected virtual void SetDamage(IDamageble obj, float damage)
        {
            if (obj != null)
            {
                obj.GetDamage(damage);
            }
            
        }
        
        
    }
}
