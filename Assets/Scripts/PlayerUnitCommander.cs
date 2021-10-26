using System;
using UnitSelector;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUnitCommander : MonoBehaviour, IUnitCommander
{
    [SerializeField] private Selector _selector;
    [SerializeField] private PlayerMouseInput _playerMouseInput;
    [SerializeField] private ClickableObject _terrainClickableObject;
    
    private readonly UnitsMover _unitsMover = new UnitsMover();

    private void OnEnable()
    {
        _terrainClickableObject.ClickRmb += TryMoveUnits;
        _playerMouseInput.AddMouseHandler(MouseButton.LeftMouse, MouseState.Down, _selector.StartSelecting);
        _playerMouseInput.AddMouseHandler(MouseButton.LeftMouse, MouseState.Hold, _selector.Select);
        _playerMouseInput.AddMouseHandler(MouseButton.LeftMouse, MouseState.Up, _selector.StopSelecting);
    }
    

    private void OnDisable()
    {
        _terrainClickableObject.ClickRmb -= TryMoveUnits;
        
        _playerMouseInput.RemoveHandler(_selector.StartSelecting);
        _playerMouseInput.RemoveHandler(_selector.Select);
        _playerMouseInput.RemoveHandler(_selector.StopSelecting);
    }

    private void TryMoveUnits(Vector3 point)
    {
        if(!_selector.HasSelectedUnits)
            return;
        
        _unitsMover.MoveGroupTo(point, _selector.SelectedUnits);
    }
}