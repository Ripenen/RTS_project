using UnityEngine;

public interface IMovable
{
    public bool CanMoveTo(Vector3 point);
    public void MoveTo(Vector3 point);
}