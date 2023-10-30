using BuffSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IOnPlayerDamageEvent: IEntityEvent<EntityBase, EntityBase, float>
{

}
public interface IOnPlayerDamageAction : IEntityAction<EntityBase, EntityBase, float>
{

}

//[SerializeField]
//public interface IOnDamageEvent
//{
//    [Serializable] public class OnDamageEvent : UnityEvent<EntityBase, EntityBase, float> { }
//    [SerializeField] public OnDamageEvent PlayerOnDamageEvent { get; set; }
//    public void RaiseDamageEvent(EntityBase victimEntity, EntityBase enemyEntity, float value);
//}

//[SerializeField]
//public interface IOnDamageAction
//{
//    public void DamageAction(EntityBase victimEntity, EntityBase enemyEntity, float value);
//}

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

    [RequireInterface(typeof(IOnPlayerDamageEvent))]
    [SerializeField]
    private UnityEngine.Object m_onDamageEventSOObject;

    private IOnPlayerDamageEvent OnDamageEventSO => m_onDamageEventSOObject as IOnPlayerDamageEvent;

    public override void GetDamage(EntityBase enemyEntity, float damage)
    {
        m_health -= damage;

        RaiseDamageEvent(this, enemyEntity, damage);
    }

    [ContextMenu("TestGetDamage")]
    public void TestGetDamage()
    {
        GetDamage(null, 100);
    }

    public override void SetDamage(EntityBase entity)
    {
        //Calc damage
        float attack = m_attack * UnityEngine.Random.Range(0.9f, 1.1f);
        float critDamage = UnityEngine.Random.Range(0f, 1f) < m_critRate ? m_critDamage : 0;
        float damage = Mathf.Max((attack - entity.Defence), 0) + critDamage;

        //Set Damage to entity
        entity.GetDamage(this, damage);
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

    public void RaiseDamageEvent(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {
        OnDamageEventSO.EntityEvent?.Invoke(victimEntity, enemyEntity, value);
    }
}
