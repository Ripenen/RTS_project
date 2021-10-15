using System;
using UnitSelector;
using UnityEngine;

public class PlayerUnitCommander : MonoBehaviour, IUnitCommander
{
    [SerializeField] private Selector _selector;
    [SerializeField] private PlayerMouseInput _playerMouseInput;
    
    private UnitsMover _unitsMover = new UnitsMover();

    private void OnEnable()
    {
        _playerMouseInput.MouseDown += _selector.StartSelecting;
        _playerMouseInput.MouseHold += _selector.Select;
        _playerMouseInput.MouseUp += _selector.StopSelecting;
        _playerMouseInput.MouseUp += TryMoveUnits;
    }
    

    private void OnDisable()
    {
        _playerMouseInput.MouseDown -= _selector.StartSelecting;
        _playerMouseInput.MouseHold -= _selector.Select;
        _playerMouseInput.MouseUp -= _selector.StopSelecting;
        _playerMouseInput.MouseUp -= TryMoveUnits;
    }

    private void TryMoveUnits()
    {
        
    }
    
}