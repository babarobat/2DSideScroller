using UnityEngine;
using Zenject;


namespace Game
{
    class UiManager:MonoBehaviour
    {
        [Inject]
        InputController _input;

        public void SetHor(int value)
        {
            _input.SetHorRaw(value);
        }
        public void Fire(bool value )
        {
            _input.SetFire(value);
        }


    }
}
