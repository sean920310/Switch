using BuffSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* Player Event Interface*/
public interface IOnPlayerDamageEvent: IEntityEvent<EntityBase, EntityBase, float> { }
public interface IOnPlayerDamageAction : IEntityAction<EntityBase, EntityBase, float> { }

public interface IOnPlayerAttackEvent : IEntityEvent<EntityBase, EntityBase, float> { }
public interface IOnPlayerAttackAction : IEntityAction<EntityBase, EntityBase, float> { }

public class PlayerEntity : EntityBase
{

    public enum EntityParameter
    {
        health,
        regenerate,
        attack,
        defence,
        speed,
        critRate,
        critDamage,
    }

    [SerializeField]
    private float m_critRate;
    [SerializeField]
    private float m_critDamage;


    [Header("Player Event")]

    [RequireInterface(typeof(IOnPlayerDamageEvent))]
    [SerializeField]
    private UnityEngine.Object m_onDamageEventSOObject;

    [RequireInterface(typeof(IOnPlayerAttackEvent))]
    [SerializeField]
    private UnityEngine.Object m_onAttackEventSOObject;

    private IOnPlayerDamageEvent OnDamageEventSO => m_onDamageEventSOObject as IOnPlayerDamageEvent;
    private IOnPlayerAttackEvent OnAttackEventSO => m_onAttackEventSOObject as IOnPlayerAttackEvent;

    public override void GetDamage(EntityBase enemyEntity, float damage)
    {
        m_health -= damage;

        RaiseDamagedEvent(this, enemyEntity, damage);
    }

    public override void SetDamage(EntityBase entity)
    {
        //Calc damage
        float attack = m_attack * UnityEngine.Random.Range(0.9f, 1.1f);
        float critDamage = UnityEngine.Random.Range(0f, 1f) < m_critRate ? m_critDamage : 0;
        float damage = Mathf.Max((attack - entity.Defence), 0) + critDamage;

        //Set Damage to entity
        entity.GetDamage(this, damage);

        RaiseDamagedEvent(entity, this, damage);
    }

    public void ChangeParameter(EntityParameter entityParameter, float value)
    {
        switch (entityParameter)
        {
            case EntityParameter.health:

                break;
            case EntityParameter.regenerate:
                break;
            case EntityParameter.attack:
                m_attack += m_initData.Attack * value;
                break;
            case EntityParameter.defence:
                break;
            case EntityParameter.speed:
                break;
            case EntityParameter.critRate:
                break;
            case EntityParameter.critDamage:
                break;
            default:
                break;
        }
    }


    [ContextMenu("TestGetDamage")]
    private void TestGetDamage()
    {
        GetDamage(null, 100);
    }

    public void RaiseDamagedEvent(EntityBase victimEntity, EntityBase enemyEntity, float damage)
    {
        OnDamageEventSO.EntityEvent?.Invoke(victimEntity, enemyEntity, damage);
    }
    public void RaiseAttackEvent(EntityBase victimEntity, EntityBase enemyEntity, float damage)
    {
        OnAttackEventSO.EntityEvent?.Invoke(victimEntity, enemyEntity, damage);
    }
}
