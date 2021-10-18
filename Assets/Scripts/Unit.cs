using System;
using UnityEngine;

public class Unit : UnitBase, IDamageable, IMovable
{
    public readonly IUnitCommander Owner = new PlayerUnitCommander();
    
    [SerializeField] protected uint _health;
    
    

    public bool IsEnemy(Unit unit) => !ReferenceEquals(unit.Owner, Owner);

    public event Action OnDead;

    public void TakeDamage(uint damage)
    {
        OnTakeDamage();
        
        if (_health < damage)
        {
            _health = 0;
            OnDead?.Invoke();
            Dead();
        }
        else
        {
            _health -= damage;
        }
    }

    protected virtual void Dead() { Destroy(gameObject); }
    protected virtual void OnTakeDamage() { }
    protected virtual void OnMove() { }
    public void TryMoveTo(Vector3 point)
    {
        _agent.SetDestination(point);
        OnMove();
    }
}
