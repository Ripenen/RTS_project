using System;
using UnityEngine;

public class PlayerMouseInput : MonoBehaviour
{
    public event Action MouseDown;
    public event Action MouseUp;
    public event Action MouseHold;
    
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
            MouseUp?.Invoke();
        
        if(Input.GetMouseButtonDown(0))
            MouseDown?.Invoke();
        
        if(Input.GetMouseButton(0))
            MouseHold?.Invoke();
    }
}