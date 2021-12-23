using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsMover
{
    public void MoveGroupTo(Vector3 point, IEnumerable<Unit> units)
    {
        var unitsList = units.ToList();

        Vector3 vectorSum = Vector3.zero;
        foreach (var unit in unitsList)
        {
            vectorSum += unit.transform.position;
        }

        var center = vectorSum / unitsList.Count;
        foreach (var unit in unitsList)
        {
            unit.TryMoveTo(point + (unit.transform.position - center).normalized * 2);
        }
    }      
}