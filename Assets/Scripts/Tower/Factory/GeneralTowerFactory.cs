using UnityEngine;

[CreateAssetMenu(fileName = "General Tower Factory", menuName = "Factories/Tower/General")]
public class GeneralTowerFactory : TowerFactory
{
    [SerializeField] private TowerConfig _testTower;
    protected override TowerConfig GetConfig(TowerType type)
    {
        switch (type)
        {
            case TowerType.TestTower:
                return _testTower;
        }

        return _testTower;
    }
}