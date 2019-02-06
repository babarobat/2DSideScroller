using Game.Interfaces;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    sealed class Rocket : BaseAmmunition, IMoveble
    {
        private Rigidbody2D _rigidBody;
        private void Update()
        {
            Move(Vector3.right,Speed*Time.deltaTime);
        }
        public void Move(Vector2 dir, float speed)
        {
            _rigidBody.velocity = dir * speed;
        }
        protected override void Awake()
        {
            base.Awake();
            _rigidBody = GetComponent<Rigidbody2D>();
        }
    }
}
