using UnityEngine;
using UnityEngine.AI;

public class SwordMan : Unit, ISelectable
{
    protected override void Dead()
    {
    }

    public void OnSelect()
    {
        Debug.Log("selected");
    }

    public void OnDeselect()
    {
    }
}