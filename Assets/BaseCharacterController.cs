using Game.Interfaces;
using System;
using UnityEngine;

namespace Game
{
    abstract class BaseCharacterController : BaseObjScene
    {
       
        protected float _startSpeed;
        public float StartSpeed
        {
            get => _startSpeed;
            set => _startSpeed = value < 0 ? 0 : value;
        }

        protected float _currentSpeed;
        public float CurrentSpeed
        {
            get => _currentSpeed;
            set => _currentSpeed = value < 0 ? 0 : value;
        }
        protected float _startHealth;
        public float StartHealth
        {
            get => _startHealth;
            set => _startHealth = value < 0 ? 0 : value;
        }
        protected float _currentHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (value < 0)
                {
                    _currentHealth = 0;
                    OnDead?.Invoke();
                    OnHpChage(_currentHealth);
                }
                else
                {
                    _currentHealth = value;
                    OnHpChage?.Invoke(_currentHealth);
                }
            }

        }
        public event Action<float> OnHpChage;
        public event Action OnDead;

        
        
        protected virtual void Death()
        {
            print($"{name} Dead");
            Destroy(gameObject);

        }
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
        public void Flip()
        {
            LookingRight = !LookingRight;
        }

    }
}
