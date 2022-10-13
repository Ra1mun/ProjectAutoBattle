using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamageDealer : MonoBehaviour, IDamageDealer
{
    private Enemy _enemy;

    private float _attackTime;
    
    public void TryDamage(Entity target)
    {
        if (_attackTime <= 0)
        {
            _attackTime = Constants.ATTTACK_INTERVAL;
            target.ApplyDamage(_enemy.Damage);
        }

        _attackTime -= Time.deltaTime * _enemy.AttackSpeed;
    }
    
    public void Rest()
    {
        _attackTime = 0;
    }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
}
