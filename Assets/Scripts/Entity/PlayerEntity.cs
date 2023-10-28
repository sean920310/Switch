using BuffSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEntity : EntityBase, IOnDamageAction
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

    [Serializable] public class OnDamageEvent : UnityEvent<EntityBase, EntityBase, float> { }

    public OnDamageEvent OnDamageCallback;

    private IOnDamageAction.OnDamageEvent m_PlayerOnDamageEvent;

    public IOnDamageAction.OnDamageEvent PlayerOnDamageEvent { get { return m_PlayerOnDamageEvent; } set { PlayerOnDamageEvent = m_PlayerOnDamageEvent; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GetDamage(EntityBase enemyEntity, float damage)
    {
        m_health -= damage;

        if(enemyEntity != this)
        {
            RaiseDamageEvent(this, enemyEntity, damage);
        }
    }

    [ContextMenu("TestGetDamage")]
    public void TestGetDamage()
    {
        GetDamage(null, 666);
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
        OnDamageCallback?.Invoke(this, enemyEntity, value);
    }
}
