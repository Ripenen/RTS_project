using System;

public interface IDamageable
{
    public event Action OnDead;
    public void TakeDamage(uint damage);
}