using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allies : Entity
{
    private float _moveSpeed;

    public void Initialize(float moveSpeed, int maxHealth, float attackDistance,
        float attackSpeed, int damage, EntityType type)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _moveSpeed = moveSpeed;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _type = type;
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {
    }
}
