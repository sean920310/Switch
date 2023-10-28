using BuffSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Player Get Damage Channel
/// </summary>
[CreateAssetMenu(fileName = "PlayerOnDamageSO", menuName = "Player Event/Create PlayerOnDamageSO")]
public class PlayerOnDamageSO : ScriptableObject, IOnDamageAction
{
    public IOnDamageAction.OnDamageEvent m_PlayerOnDamageEvent;

    public IOnDamageAction.OnDamageEvent PlayerOnDamageEvent { get { return m_PlayerOnDamageEvent; } set { PlayerOnDamageEvent = m_PlayerOnDamageEvent;} }

    public void RaiseDamageEvent(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {
        m_PlayerOnDamageEvent?.Invoke(victimEntity, enemyEntity, value);
    }
}
