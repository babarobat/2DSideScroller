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
        private bool _canFire;
        [SerializeField]
        private Transform _firePoint;
        [Inject]
        private SignalBus _signalBus;

        
        private BaseAmmunition _bulletPrefab;

        public void GetDamage(float damage)
        {
            
            CurrentHealth -= damage;
        }

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
            
            _bulletPrefab = _config.RocketPrefab;
            Reload();

        }
        
        void Reload()
        {
            _canFire = true;
        }

        public void Fire()
        {
            var tmpBullet = _rocketFactory.Create(_config);
            tmpBullet.transform.position = _firePoint.position;
            tmpBullet.transform.rotation = transform.rotation;
            _canFire = false;
            Invoke("Reload", FireRate);
        }
        protected override void OnDead()
        {
            base.OnDead();
            _signalBus.TryFire<OnPlayerDead>();
            Destroy(gameObject);
        }

    }
}
