using System;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class Player : Entity
{
    private IDamageDealer _damageDealer;
    
    private float _moveSpeed;
    
    private PhysicsMovement _physicsMovement;

    public void Initialize(int maxHealth, float attackDistance, float attackSpeed, int damage, float moveSpeed)
    {
        _maxHealth = maxHealth;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _moveSpeed = moveSpeed;
    }
    
    public override void OnUpdate(ITargetFinder targetFinder)
    {
        
    }
    
    private void Start()
    {
        _currentHealth = _maxHealth;

        _physicsMovement.Init(_moveSpeed);
    }
    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
        _damageDealer = GetComponent<IDamageDealer>();
    }

}
