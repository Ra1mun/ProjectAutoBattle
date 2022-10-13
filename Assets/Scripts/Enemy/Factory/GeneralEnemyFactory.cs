using UnityEngine;

[CreateAssetMenu(fileName = "General Enemy Factory", menuName = "Factories/Enemy/General")]
public class GeneralEnemyFactory : EnemyFactory
{
    [SerializeField] private EnemyConfig _testEnemy;
    protected override EnemyConfig GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.TestEnemy:
                return _testEnemy;
        }
        return _testEnemy;
    }
}
