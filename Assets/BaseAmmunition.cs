using UnityEngine;
using Game.Interfaces;

namespace Game
{
    public abstract class BaseAmmunition:BaseObjScene
    {
        [SerializeField]
        protected float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value < 0 ? 0 : value; 
        }
        [SerializeField]
        protected float _damage;
        public float Damage
        {
            get => _damage;
            set => _damage = value < 0 ? 0 : value;
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            collision.transform.GetComponent<IDamageble>()?.GetDamage(Damage);
            print($"{name} hit  {collision.transform.name}");
            Destroy(gameObject);
            return;
        }
        
        
    }
}
