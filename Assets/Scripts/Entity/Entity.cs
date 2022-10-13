using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IHealth, IDamageable
{
    protected EntityType _type;
    public EntityType Type => _type;

    protected int _maxHealth;
    protected int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public event Action<Entity> OnDie;

    protected float _attackDistance;
    protected float _attackSpeed;
    public float AttackSpeed => _attackSpeed;
    protected int _damage;
    public int Damage => _damage;
    
    private bool IsAlive()
    {
        return _currentHealth > 0;
    }

    public abstract void OnUpdate(ITargetFinder targetFinder);
    
    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_maxHealth, _currentHealth);
        
        if (!IsAlive())
        {
            OnDie?.Invoke(this);
        }
    }
}
