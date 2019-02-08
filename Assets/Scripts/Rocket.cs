using Game.Interfaces;
using UnityEngine;
using Zenject;

namespace Game
{
    /// <summary>
    /// Логика и параметры ракеты
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    sealed class Rocket : BaseAmmunition, IMoveble
    {
        /// <summary>
        /// Ссылка на компонент твердого тела
        /// </summary>
        private Rigidbody2D _rigidBody;
        /// <summary>
        /// Время, после которого ракета уничтожается
        /// </summary>
        private const float lifeTime = 5;
        /// <summary>
        /// Урон
        /// </summary>
        private const float damage = 1;
        /// <summary>
        /// Параметры игры
        /// </summary>
        [Inject]
        private GameConfig _config;

        private void Update()
        {
            Move(Vector2.right, Speed*Time.deltaTime);
        }
        /// <summary>
        /// логика движения
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="speed"></param>
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
