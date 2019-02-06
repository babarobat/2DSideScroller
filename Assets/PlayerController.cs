using Game.Interfaces;
using UnityEngine;
using Zenject;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    class PlayerController:BaseCharacterController,IMoveble, IDamageble
    {
        [Inject]
        private GameConfig _config;
        private WeaponController _weaponController;
        [Inject]
        private InputController _input;
        public void GetDamage(float damage)
        {
            CurrentHealth -= damage;
        }

        public void Move(Vector2 dir, float speed)
        {
            Transform.position += (Vector3)dir * speed;
            
        }
        void Fire()
        {
            _weaponController.Fire();
        }
        private void Update()
        {
            var dir = _input.Horizontal*Vector2.right * Time.deltaTime;
            
            Move(dir, _currentSpeed);
            FaceTowards(_input.Horizontal);
            if (_input.Fire)
            {
                Fire();
            }
        }
        protected override void Awake()
        {
            base.Awake();
            CurrentSpeed = _config.PlayerMovementSpeed;
        }
        void FaceTowards(float x)
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
