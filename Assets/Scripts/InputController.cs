using UnityEngine;

 class InputController:MonoBehaviour  {
    
    /// <summary>
    /// Значение пользовательского ввода по оси Horizontal.
    /// Принимает значение -1,0,1;
    /// </summary>
	public float Horizontal { get; private set; }
    /// <summary>
    /// Получать команды управления из кнопок UI
    /// </summary>
    private bool _controlFormButtons;
    /// <summary>
    /// Стрелять?
    /// </summary>
    public bool Fire { get; private set; }

    private void Update()
    {
        if (!_controlFormButtons)
        {
            Fire = Input.GetKeyDown(KeyCode.Space);
            Horizontal = Input.GetAxisRaw("Horizontal");
        }
    }
    /// <summary>
    /// назначить значение по ос Horizontal
    /// </summary>
    /// <param name="value"></param>
    public void SetHorRaw(float value)
    {
        if (value != 0)
        {
            _controlFormButtons = true;
            Horizontal = value;
        }
        else
        {
            _controlFormButtons = false;
        }   
    }
    /// <summary>
    /// Стрелять?
    /// </summary>
    /// <param name="value"></param>
    public void SetFire(bool value)
    {
        if (value)
        {
            _controlFormButtons = true;
            Fire = value;
        }
        else
        {
            _controlFormButtons = false;

        }
        
    }
    
}
