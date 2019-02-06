using Zenject;
using UnityEngine;

 class InputController:MonoBehaviour  {
    
    /// <summary>
    /// Значение пользовательского ввода по оси Horizontal.
    /// Принимает значение -1,0,1;
    /// </summary>
	public float Horizontal { get; private set; }
    
    
    public bool Fire { get; private set; }

    private void Update()
    {
        
        Horizontal = Input.GetAxisRaw("Horizontal");
    }
    public void SetHorRaw(float value)
    {
        Horizontal = value < 0 ? -1 : value > 0 ? 1 : 0;
        Fire = Input.GetKeyDown(KeyCode.Space); 
    }
    public void SetFire(bool value)
    {
        Fire = value;
    }
    
}
