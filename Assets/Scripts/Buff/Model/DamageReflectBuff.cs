using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using BuffSystem.Model;

[CreateAssetMenu(fileName = "DamageReflectBuff", menuName = "Buff/Create DamageReflectBuff")]
public class DamageReflectBuff : ScriptableObject, IDamageEvent
{
    public void DamageEvent(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {
        Debug.Log("EnemyGetREFLECTDAMAGE: " + value);

        enemyEntity?.GetDamage(enemyEntity, value);
    }
}
