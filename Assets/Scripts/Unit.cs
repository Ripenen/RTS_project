using System;
using UnityEngine;

public class Unit : UnitBase, IDamageable, IMovable
{
    public readonly IUnitCommander Owner = new PlayerUnitCommander();
    
    [SerializeField] protected uint _health;
    [SerializeField] protected float _speed;
    
    

    public bool IsEnemy(Unit unit) => !ReferenceEquals(unit.Owner, Owner);

    public event Action Dead;

    public void TakeDamage(uint damage)
    {
        OnTakeDamage();
        
        _health -= damage;

        if (_health <= 0)
        {
            Dead?.Invoke();
            OnDead();
        }
    }

    public void TryMoveTo(Vector3 point)
    {
        _agent.speed = _speed;
        _agent.SetDestination(point);
        OnMove();
    }

    protected virtual void OnDead() { Destroy(gameObject); }

    protected virtual void OnTakeDamage() { }

    protected virtual void OnMove() { }
}
