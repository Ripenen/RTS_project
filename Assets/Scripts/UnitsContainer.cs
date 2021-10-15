using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsContainer : MonoBehaviour
{
    private readonly List<Unit> _unitsOnScene = new List<Unit>();

    private void Start()
    {
        _unitsOnScene.AddRange(FindObjectsOfType<Unit>());
    }

    public void Add(Unit unit)
    {
        if(_unitsOnScene.Contains(unit))
            return;
        
        _unitsOnScene.Add(unit);
        
        unit.OnDead += () =>
        {
            _unitsOnScene.Remove(unit);
        };
    }

    public IEnumerable<Unit> GetUnitsByCommander<T>() where T : IUnitCommander =>
        _unitsOnScene.Where(unit => unit.Owner.GetType() == typeof(T));

    public IEnumerable<Unit> GetUnitsByCommander(IUnitCommander commander)
    {
        return _unitsOnScene.Where(unit => unit.Owner == commander);
    }

    public IEnumerable<ISelectable> GetSelectableUnits()
    {
        return _unitsOnScene.Where(unit => unit is ISelectable).Cast<ISelectable>();
    }
}
