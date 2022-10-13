using UnityEngine;

public abstract class TowerFactory : ScriptableObject
{
    public Tower Spawn(TowerType type, Vector3 transform)
    {
        var config = GetConfig(type);
        Tower instance = Instantiate(config.Prefab, transform, Quaternion.identity);
        instance.Initialize(config.MaxHealth, config.AttackDistance, config.AttackSpeed,
            config.Damage, EntityType.Allies);
        
        return instance;
    }

    protected abstract TowerConfig GetConfig(TowerType type);
}
