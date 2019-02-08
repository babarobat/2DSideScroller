using UnityEngine;

namespace Game
{
    /// <summary>
    /// Базовый интерактивный обьект сцены
    /// </summary>
    public abstract class BaseObjScene:MonoBehaviour
    {
        /// <summary>
        /// Положение, поворот и размер обьекта
        /// </summary>
        protected Transform Transform { get; private set; }
        /// <summary>
        /// Включает и отклюет обьект путем выключения GameObject, на котором лежит скрипт
        /// </summary>
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
