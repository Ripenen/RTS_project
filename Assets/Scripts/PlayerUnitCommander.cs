using System;
using UnitSelector;
using UnityEngine;

public class PlayerUnitCommander : MonoBehaviour, IUnitCommander
{
    [SerializeField] private Selector _selector;
    [SerializeField] private PlayerMouseInput _playerMouseInput;
    [SerializeField] private ClickableObject _terrainClickableObject;
    
    private readonly UnitsMover _unitsMover = new UnitsMover();

    private void OnEnable()
    {
        _playerMouseInput.MouseDown += _selector.StartSelecting;
        _playerMouseInput.MouseHold += _selector.Select;
        _playerMouseInput.MouseUp += _selector.StopSelecting;
        _terrainClickableObject.OnClickRmb += TryMoveUnits;
    }
    

    private void OnDisable()
    {
        _playerMouseInput.MouseDown -= _selector.StartSelecting;
        _playerMouseInput.MouseHold -= _selector.Select;
        _playerMouseInput.MouseUp -= _selector.StopSelecting;
        _terrainClickableObject.OnClickRmb -= TryMoveUnits;
    }

    private void TryMoveUnits(Vector3 point)
    {
        _unitsMover.TryMoveAllTo(point, _selector.SelectedUnits);
    }
    
}