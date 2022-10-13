using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : ScriptableObject
{
    public Enemy Spawn(EnemyType type, Vector3 transform)
    {
        var config = GetConfig(type);
        Enemy instance = Instantiate(config.Prefab, transform, Quaternion.identity);
        instance.Initialize(config.MoveSpeed, config.MaxHealth, config.AttackDistance,
            config.AttackSpeed, config.Damage, EntityType.Enemy);

        return instance;
    }

    protected abstract EnemyConfig GetConfig(EnemyType type);
}
