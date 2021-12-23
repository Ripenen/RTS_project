using UnityEngine;
using UnityEngine.AI;

public class SwordMan : Unit, ISelectable
{
    protected override void OnDead()
    {
    }

    public void OnSelect()
    {
        SetUnitColor(Color.red);
    }

    public void OnDeselect()
    {
        SetUnitColor(Color.white);
    }
}