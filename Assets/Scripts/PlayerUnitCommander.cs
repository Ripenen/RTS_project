using UnitSelector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerUnitCommander : MonoBehaviour, IUnitCommander
{
    [SerializeField] private Selector _selector;
    [SerializeField] private PlayerMouseInput _playerMouseInput;
    [SerializeField] private Camera _camera;
    
    private readonly UnitsMover _unitsMover = new UnitsMover();

    private void OnEnable()
    {
        _playerMouseInput.AddMouseHandler(MouseButton.RightMouse, MouseState.Up, TryMoveUnits);
        
        _playerMouseInput.AddMouseHandler(MouseButton.LeftMouse, MouseState.Down, _selector.StartSelecting);
        _playerMouseInput.AddMouseHandler(MouseButton.LeftMouse, MouseState.Hold, _selector.Select);
        _playerMouseInput.AddMouseHandler(MouseButton.LeftMouse, MouseState.Up, _selector.StopSelecting);
    }
    

    private void OnDisable()
    {
        _playerMouseInput.RemoveHandler(TryMoveUnits);
        
        _playerMouseInput.RemoveHandler(_selector.StartSelecting);
        _playerMouseInput.RemoveHandler(_selector.Select);
        _playerMouseInput.RemoveHandler(_selector.StopSelecting);
    }

    private void TryMoveUnits()
    {
        if(!_selector.HasSelectedUnits)
            return;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hitInfo))
        {
            if (NavMesh.SamplePosition(hitInfo.point, out var navMeshHit, 0.1f,NavMesh.AllAreas))
            {
                _unitsMover.MoveGroupTo(navMeshHit.position, _selector.SelectedUnits);
            }
            
        }
    }
}