using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsMover
{
    public void MoveGroupTo(Vector3 point, IEnumerable<Unit> units)
    {
        var unitsList = units.ToList();
        /*
        foreach (var unit in units)
        {
            unit.TryMoveTo(point);
        }*/

        var centerPos = unitsList[0].transform.position;
        unitsList[0].TryMoveTo(point);
        for (int i = 1; i < unitsList.Count; i++)
        {
            unitsList[i].TryMoveTo(point + (unitsList[i].transform.position - centerPos));
        }
    }      
}