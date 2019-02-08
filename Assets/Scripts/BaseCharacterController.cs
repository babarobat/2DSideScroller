using Game.Interfaces;
using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Базовый контроллер управления персонажами
    /// </summary>
    abstract class BaseCharacterController : BaseObjScene
    {
        /// <summary>
        /// Скорость передвижения
        /// </summary>
        protected float _speed;
        /// <summary>
        /// Скорость передвижения
        /// </summary>
        public float Speed
        {
            get => _speed;
            set => _speed = value < 0 ? 0 : value;
        }
        /// <summary>
        /// Начальное здоровье
        /// </summary>
        protected float _startHealth;
        /// <summary>
        /// Начальное здоровье
        /// </summary>
        public float StartHealth
        {
            get => _startHealth;
            set => _startHealth = value < 0 ? 0 : value;
        }
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        protected float _currentHealth;
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (value <= 0)
                {
                    _currentHealth = 0;
                    OnDead();
                }
                else
                {
                    _currentHealth = value;
                    OnHpChange();
                }
            }

        }
        

        
        /// <summary>
        /// Вызывается во время смерти
        /// </summary>
        protected virtual void OnDead()
        {
            print($"{name} Dead");
            Destroy(gameObject);
        }
        /// <summary>
        /// Вызывается во время зменения здоровья
        /// </summary>
        protected virtual void OnHpChange()
        {
            print($"{name} осталось {CurrentHealth} hp");
            
        }
        /// <summary>
        /// Персонаж смотрит направо?
        /// </summary>
        public bool LookingRight
        {
            get
            {
                if (Transform.eulerAngles.y == 0)
                {
                    return true;
                }
                else if (Transform.eulerAngles.y == 180)
                {
                    return false;
                }
                else
                {
                    throw new Exception($"Wrong sprite rotation on {name}");
                }   
                  
            }

            set => Transform.eulerAngles = value == true ? Vector3.up * 0 : Vector3.up * 180;
        }
        /// <summary>
        /// Перевернуть персонажа
        /// </summary>
        protected virtual void Flip()
        {
            LookingRight = !LookingRight;
        }
        /// <summary>
        /// Смотреть в сторону: положительное значение x - направо,
        /// отрицательное - налево
        /// </summary>
        /// <param name="x"></param>
        protected  virtual void FaceTowards(float x)
        {
            if (x < 0)
            {
                LookingRight = false;
            }
            if (x > 0)
            {
                LookingRight = true;
            }
        }

    }
}
