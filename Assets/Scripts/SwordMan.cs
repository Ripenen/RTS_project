using UnityEngine;
using UnityEngine.AI;

public class SwordMan : Unit, IMovable, ISelectable
{
    protected override void Dead()
    {
    }

    public bool CanMoveTo(Vector3 point) => _agent.CalculatePath(point, new NavMeshPath());

    public void MoveTo(Vector3 point)
    {
        // Animations
        transform.Translate(transform.position - point);
        _agent.SetDestination(point);
    }

    public void OnSelect()
    {
        Debug.Log("selected");
    }

    public void OnDeselect()
    {
    }
}