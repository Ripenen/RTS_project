using System;

public interface IDamageable
{
    public event Action Dead;
    public void TakeDamage(uint damage);
}