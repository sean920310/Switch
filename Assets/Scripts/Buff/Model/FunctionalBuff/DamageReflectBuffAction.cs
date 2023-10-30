using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using BuffSystem.Model;

[CreateAssetMenu(fileName = "DamageReflectBuffAction", menuName = "Buff/Create DamageReflectBuffAction")]
public class DamageReflectBuffAction : ScriptableObject, IOnPlayerDamageAction
{
    [SerializeField] private float ReflectDamagePercent;

    // On Player Damage Action, this is about damage reflection.
    public void EntityAction(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {
        Debug.Log("Enemy Get reflect damage: " + value);

        if(enemyEntity != null && victimEntity != enemyEntity)
        {
            enemyEntity.GetDamage(enemyEntity, value * ReflectDamagePercent);
        }
    }
}
