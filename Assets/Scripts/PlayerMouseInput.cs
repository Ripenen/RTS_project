using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMouseInput : MonoBehaviour
{
    private readonly MouseHandlerInvoker _handlerInvoker = new MouseHandlerInvoker();

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if(Input.GetMouseButtonDown(i))
                _handlerInvoker.Invoke((MouseButton)i, MouseState.Down);
            
            if(Input.GetMouseButton(i))
                _handlerInvoker.Invoke((MouseButton)i, MouseState.Hold);
            
            if(Input.GetMouseButtonUp(i))
                _handlerInvoker.Invoke((MouseButton)i, MouseState.Up);
        }
    }

    public void AddMouseHandler(MouseButton button, MouseState state, Action action)
    {
        _handlerInvoker.Add(new MouseHandler(button, state, action));
    }

    public void RemoveHandler(Action action) => _handlerInvoker.RemoveHandler(action);
}

public enum MouseState
{
    Down,
    Hold,
    Up,
}

public readonly struct MouseHandler
{
    public readonly MouseButton MouseButton;
    public readonly MouseState State;
    public readonly Action Action;

    public MouseHandler(MouseButton mouseButton, MouseState state, Action action)
    {
        MouseButton = mouseButton;
        State = state;
        Action = action;
    }
}

public class MouseHandlerInvoker
{
    private readonly List<MouseHandler> _mouseHandlers = new List<MouseHandler>();

    public void Add(MouseHandler mouseHandler) => _mouseHandlers.Add(mouseHandler);
    public void RemoveHandler(Action action) => _mouseHandlers.RemoveAll(mouseHandler => mouseHandler.Action == action);

    public void Invoke(MouseButton button, MouseState state)
    {
        foreach (var mouseHandler in _mouseHandlers)
            if(mouseHandler.MouseButton == button && mouseHandler.State == state)
                mouseHandler.Action.Invoke();
    }
}