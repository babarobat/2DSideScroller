using UnityEngine;
using System;
namespace Game
{
    
    public abstract class BaseWeapon:MonoBehaviour
    {
        public bool IsActive;
        protected Transform firePosAndRot;
        [SerializeField]
        protected BaseAmmunition _ammo;
        protected float _fireRate;
        private DateTime _lastShotTime;
        public bool CanFire
        {
            get
            {
                return (DateTime.Now - _lastShotTime).Milliseconds > _fireRate * 1000 && IsActive;
            }
        }
        private void Awake()
        {
            _lastShotTime = DateTime.Now;
            IsActive = false;
        }
        public float FireRate
        {
            get => _fireRate;
            set => _fireRate = value < 0 ? 0 : value;
        }
        public abstract void Fire();
        

    }
}
