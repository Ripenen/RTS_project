using System.Collections.Generic;
using UnityEngine;

public class UnitsMover
{
    public void TryMoveAllTo(Vector3 point, IEnumerable<Unit> units)
    {
        foreach (var unit in units)
        {
            unit.TryMoveTo(point);
        }
    }      
}