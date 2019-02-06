using UnityEngine;
using Game.Interfaces;
namespace Game
{
    public sealed class Canon : BaseWeapon
    {
        public override void Fire()
        {
            if (CanFire)
            {
                var tmpBullet = Instantiate(_ammo, firePosAndRot.position, firePosAndRot.rotation);
            }
        }

        
    }
}
