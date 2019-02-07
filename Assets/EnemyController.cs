using UnityEngine;
using Game.Interfaces;
using Zenject;

namespace Game
{
    /// <summary>
    /// Контроллер танка. После спавна едет в направлении _moveDir: -1 - налево, 1- направо.
    /// </summary>
    class EnemyController : BaseCharacterController, IMoveble, IDamageble
    {
        /// <summary>
        /// Ссылка на параметры игры
        /// </summary>
        [Inject]
        private GameConfig _config;
        /// <summary>
        /// Направление движения
        /// </summary>
        [Inject]
        private int _moveDir;
        /// <summary>
        /// Урон
        /// </summary>
        private const float damage = 1;

        protected override void Awake()
        {
            base.Awake();
            StartHealth = _config.EnemyHealth;
            CurrentHealth = StartHealth;
            Speed = _config.EnemySpeed;
        }

        /// <summary>
        /// логика получения урона
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(float damage)
        {
            CurrentHealth -= damage;
        }
        /// <summary>
        /// Движется в указанном направлении с указанной скоростью. 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="speed"></param>
        public void Move(Vector2 dir, float speed)
        {
            FaceTowards(_moveDir);
            Transform.Translate(dir * speed);
        }
        private void Update()
        {
            Move(Vector2.right, Speed*Time.deltaTime); 
        }
        protected override void OnDead()
        {
            Destroy(gameObject);
        }
        /// <summary>
        /// Логика столкновения. 
        /// </summary>
        /// <param name="collision"></param>
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            SetDamage(collision.transform.GetComponent<IDamageble>(), damage);
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
