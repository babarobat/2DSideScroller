using Game.Interfaces;
using UnityEngine;
using Zenject;
using Game.Signals;

namespace Game
{
    /// <summary>
    /// Управляет игроком
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    class PlayerController:BaseCharacterController,IMoveble, IDamageble, IFire
    {
        /// <summary>
        /// Параметры игры
        /// </summary>
        [Inject]
        private GameConfig _config;
        /// <summary>
        /// Ссылка на обработчик пользовательского ввода
        /// </summary>
        [Inject]
        private InputController _input;

        /// <summary>
        /// Фабрика для создания ракет
        /// </summary>
        [Inject]
        private RocketFactory _rocketFactory;
        /// <summary>
        /// Скорость стрельбы
        /// </summary>
        public float FireRate => _config.PlayerShootTimeOut;
        /// <summary>
        /// Можно стрелять?
        /// </summary>
        private bool _canFire;
        /// <summary>
        /// Точка появления снаряда 
        /// </summary>
        [SerializeField]
        private Transform _firePoint;
        /// <summary>
        /// Ссылка на шину с сигналами
        /// </summary>
        [Inject]
        private SignalBus _signalBus;
        /// <summary>
        /// логика получения урона
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(float damage)
        { 
            CurrentHealth -= damage;
        }
        /// <summary>
        /// логика движения
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="speed"></param>
        public void Move(Vector2 dir, float speed)
        {
            Transform.position += (Vector3)dir * speed;
            
        }
        
        private void Update()
        {
            var dir = _input.Horizontal*Vector2.right * Time.deltaTime;
            
            Move(dir, _speed);
            FaceTowards(_input.Horizontal);
            if (_input.Fire && _canFire)
            {
                Fire();
            }
        }
        protected override void Awake()
        {
            base.Awake();
            StartHealth = _config.PlayerHelth;
            CurrentHealth = StartHealth;
            Speed = _config.PlayerMovementSpeed;
            Reload();

        }
        /// <summary>
        /// Переезарядка
        /// </summary>
        void Reload()
        {
            _canFire = true;
        }
        /// <summary>
        /// логика ведения огня
        /// </summary>
        public void Fire()
        {
            var tmpBullet = _rocketFactory.Create(_config);
            tmpBullet.transform.position = _firePoint.position;
            tmpBullet.transform.rotation = transform.rotation;
            _canFire = false;
            Invoke("Reload", FireRate);
        }
        /// <summary>
        /// Действия при смерти
        /// </summary>
        protected override void OnDead()
        {
            base.OnDead();
            _signalBus.TryFire<OnPlayerDead>();
            Destroy(gameObject);
        }

    }
}
