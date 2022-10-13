public class Tower : Entity
{
    private Entity _target;

    private IDamageDealer _damageDealer;
    
    public void Initialize(int maxHealth, float attackDistance, float attackSpeed, int damage, EntityType type)
    {
        _maxHealth = maxHealth;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _type = type;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {
        
    }

    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }
}
