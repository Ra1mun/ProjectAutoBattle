using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Entity
{
    private IDamageDealer _damageDealer;

    private float _moveSpeed;

    private Entity _target;
    
    private EnemyState _state;

    private NavMeshAgent _agent;
    
    public void Initialize(float moveSpeed, int maxHealth, float attackDistance, float attackSpeed,
        int damage, EntityType type)
    {
        _moveSpeed = moveSpeed;
        _maxHealth = maxHealth;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _type = type;
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {
        switch (_state)
        {
            case EnemyState.LookForTarget:
                LookForTarget(targetFinder);
                break;
            case EnemyState.MoveToTarget:
                MoveToTarget();
                break;
            case EnemyState.AttackTarget:
                AttackTarget();
                break;
        }
    }

    private void LookForTarget(ITargetFinder targetFinder)
    {
        _target = targetFinder.FindTarget(this);
        if (_target == null)
            return;
        
        _state = EnemyState.MoveToTarget;
    }
    
    private void AttackTarget()
    {
        var distance = (transform.position - _target.transform.position).magnitude;
        if (_target == null)
        {
            _damageDealer.Rest();
            _state = EnemyState.LookForTarget;
            return;
        }

        if (distance >= _attackDistance)
        {
            _agent.isStopped = false;
            _damageDealer.Rest();
            _state = EnemyState.MoveToTarget;
            return;
        }
        
        _damageDealer.TryDamage(_target);
    }

    private void MoveToTarget()
    {
        if (_target == null)
        {
            _state = EnemyState.LookForTarget;
            return;
        }

        var distance = (transform.position - _target.transform.position).sqrMagnitude;
        if (distance <= _attackDistance)
        {
            _agent.isStopped = true;
            _state = EnemyState.AttackTarget;
            return;
        }
        
        _agent.SetDestination(_target.transform.position);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _agent.speed = _moveSpeed;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _damageDealer = GetComponent<IDamageDealer>();
    }
}
