using System;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, IDamageable
{
    public IUnitCommander Owner = new PlayerUnitCommander();
    public event Action OnDead;
    
    [SerializeField] protected int _health;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] private Renderer _renderer;

    public Bounds GetWorldBounds() => _renderer.bounds;

    public bool IsEnemy(Unit unit) => !ReferenceEquals(unit.Owner, Owner);

    public virtual void TakeDamage(int damage)
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
}
