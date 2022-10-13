using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    
    [SerializeField] private TowerFactory _towerFactory;

    public event Action<Tower> OnTowerSpawned;
    
    private void Start()
    {
        if(FindObjectOfType<Tower>() == false)
            Spawn();
    }
    
    private void Spawn()
    {
        var tower = _towerFactory.Spawn(TowerType.TestTower, _spawnPosition);
        
        OnTowerSpawned?.Invoke(tower);
    }
}
