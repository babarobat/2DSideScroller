using UnityEngine;
using System;
namespace Game
{
    [Serializable]
    class WeaponController:MonoBehaviour
    {
        private int activeWeaponIndex;
        BaseWeapon[] _weapons;
        private void Awake()
        {
            _weapons[activeWeaponIndex].IsActive = true;
        }
        public void Fire()
        {
            GetWeapon(activeWeaponIndex).Fire();
        }
        
        BaseWeapon GetWeapon(int index)
        {
            var canGetWeapon = _weapons.Length > 0 && index < _weapons.Length && index >= 0;
            if (canGetWeapon)
            {
                return _weapons[index];
            }
            throw new Exception($"Введен невреный индекс"); 
        }
    }
}
