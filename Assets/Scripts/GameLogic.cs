using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour, ITargetFinder
{
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private TowerSpawner _towerSpawner;

    [SerializeField] private Player _player;

    [SerializeField] private List<Entity> _entities;

    private void Awake()
    {
        _entities = new List<Entity>();
        
        _entities.Add(_player);
        _enemySpawner.OnEnemySpawned += OnEntitySpawned;
        _towerSpawner.OnTowerSpawned += OnEntitySpawned;
    }

    private void Update()
    {
        foreach (var entity in _entities)
        {
            entity.OnUpdate(this);
        }
    }

    private void OnDestroy()
    {
        _enemySpawner.OnEnemySpawned -= OnEntitySpawned;
        _towerSpawner.OnTowerSpawned -= OnEntitySpawned;
    }

    private void OnEntitySpawned(Entity entity)
    {
        entity.OnDie += DestroyEntity;
        _entities.Add(entity);
    }

    private void DestroyEntity(Entity entity)
    {
        entity.OnDie -= DestroyEntity;
        _entities.Remove(entity);
        Destroy(entity.gameObject);
    }

    Entity ITargetFinder.FindTarget(Entity entity)
    {
        Entity result = null;
        
        var distance = float.MaxValue;
        
        foreach (var e in _entities)
        {
            if(e.Type == entity.Type || (e.Type == EntityType.Player && entity.Type == EntityType.Allies))
                continue;
            
            var tempDistance = (entity.transform.position - e.transform.position).magnitude;
            if (tempDistance < distance)
            {
                distance = tempDistance;
                result = e;
            }
        }

        return result;
    }
}
