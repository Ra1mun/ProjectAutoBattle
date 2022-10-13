using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPositions;
    
    [SerializeField] private EnemyFactory _enemyFactory;
    
    [SerializeField] private float _delayBeforeSpawn;

    [SerializeField] private SpawnerState _state;
    
    public event Action<Enemy> OnEnemySpawned;

    private float _elapsedTime;

    private void Update()
    {
        switch (_state)
        {
            case SpawnerState.Single:
                Single();
                break;
            case SpawnerState.Update:
                OnUpdate();
                break;
        }
    }

    private void OnUpdate()
    {
        if (_elapsedTime > _delayBeforeSpawn)
        {
            Spawn();
            _elapsedTime = 0f;
        }

        _elapsedTime += Time.deltaTime;
    }
    
    private void Single()
    {
        if(FindObjectOfType<Enemy>() == false)
            Spawn();
    }
    private void Spawn()
    {
        var spawnposition = _spawnPositions.RandomItem();
        var enemy = _enemyFactory.Spawn(EnemyType.TestEnemy, spawnposition);
        
        OnEnemySpawned?.Invoke(enemy);
    }
}
