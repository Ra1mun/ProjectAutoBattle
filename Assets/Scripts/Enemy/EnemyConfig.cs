using System;
using UnityEngine.Serialization;

[Serializable]

public class EnemyConfig
{
    public Enemy Prefab;
    public float MoveSpeed;
    public int MaxHealth;
    public float AttackDistance;
    public float AttackSpeed;
    public int Damage;
}
