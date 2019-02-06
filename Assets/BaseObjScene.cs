using UnityEngine;
using Game.Interfaces;

namespace Game
{
    
    public abstract class BaseObjScene:MonoBehaviour
    {
       
        
        protected Transform Transform { get; private set; }
        protected bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        protected virtual void Awake()
        {
            Transform = transform;
            
        }
    }
}
