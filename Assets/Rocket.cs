using Game.Interfaces;
using UnityEngine;
using Zenject;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    sealed class Rocket : BaseAmmunition, IMoveble
    {
        private Rigidbody2D _rigidBody;
        private const float lifeTime = 5;
        private const float damage = 1;

        [Inject]
        private GameConfig _config;

        private void Update()
        {
            Move(Vector2.right, Speed*Time.deltaTime);
        }
        public void Move(Vector2 dir, float speed)
        {
            Transform.Translate(dir * speed);
        }
        protected override void Awake()
        {
            base.Awake();
            _rigidBody = GetComponent<Rigidbody2D>();
            Speed = _config.BulletAcceleration;
            Damage = damage;
            Destroy(gameObject, lifeTime);
        }
    }
}
