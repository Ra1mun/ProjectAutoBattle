using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public Player Player;
    public float MoveSpeed;
    public int MaxHealth;
    public float AttackDistance;
    public float AttackSpeed;
    public int Damage;

    private void Start()
    {
        Player.Initialize(MaxHealth, AttackDistance, AttackSpeed, Damage, MoveSpeed);
    }
}
