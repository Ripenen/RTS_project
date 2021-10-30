using System;
using UnityEngine;
using UnityEngine.AI;

public class Unit : UnitBase, IDamageable, IMovable
{
    public readonly IUnitCommander Owner = new PlayerUnitCommander();
    
    [SerializeField] protected int _health;
    [SerializeField] protected float _speed;

    private void Start()
    {
        _agent.speed = _speed;
    }

    public bool IsEnemy(Unit unit) => !ReferenceEquals(unit.Owner, Owner);

    public event Action Dead;

    public void TakeDamage(int damage)
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
        var path = new NavMeshPath();
        _agent.CalculatePath(point, path);

        if (path.status != NavMeshPathStatus.PathComplete) 
            return;
        
        _agent.SetPath(path);
        OnMove();
    }

    protected virtual void OnDead() { Destroy(gameObject); }

    protected virtual void OnTakeDamage() { }

    protected virtual void OnMove() { }
}
